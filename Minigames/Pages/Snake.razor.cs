
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Minigames.SnakeEnums;


namespace Minigames.Pages
{
    public partial class Snake : ComponentBase
    {
        private ElementReference gameContainer;

        private BoardState?[][] board;

        private List<(int i, int j)> snake;

        private Direction currentDirection;

        private bool? gameOver;

        private int score;

        private async Task Start()
        {
            board = new BoardState?[40][];
            snake = new List<(int i, int j)> { new(20, 20) };
            currentDirection = Direction.Right;
            gameOver = false;
            score = 0;

            for (var i = 0; i < 40; i++)
            {
                board[i] = new BoardState?[40];
            }

            board[20][20] = BoardState.Snake;
            PlaceFood();
            await gameContainer.FocusAsync();
            GameLoop();
        }

        private async Task GameLoop()
        {
            while (gameOver == false)
            {
                var delayTime = 250 - score * 10;
                if (delayTime < 50) delayTime = 50;
                await Task.Delay(delayTime);
                try
                {
                    MoveSnake();
                }
                catch (Exception ex)
                {
                    gameOver = true;
                    Console.WriteLine("Game over!");
                }
                StateHasChanged();
            }
        }

        private void PlaceFood()
        {
            var potentialSpots = new List<(int x, int y)>();
            for (var i = 0; i < 40; i++)
            {
                for (var j = 0; j < 40; j++)
                {
                    if (board[i][j] == null)
                        potentialSpots.Add((i, j));
                }
            }
            var index = new Random().Next(0, potentialSpots.Count);
            var randomSpot = potentialSpots[index];

            board[randomSpot.x][randomSpot.y] = BoardState.Food;
        }

        private void ChangeDirection(Direction direction)
        {
            currentDirection = direction;
        }

        private void KeyboardEventHandler(KeyboardEventArgs args)
        {
            switch (args.Key)
            {
                default:
                    return;
                case "a":
                case "ArrowLeft":
                    currentDirection = Direction.Left;
                    break;
                case "d":
                case "ArrowRight":
                    currentDirection = Direction.Right;
                    break;
                case "w":
                case "ArrowUp":
                    currentDirection = Direction.Up;
                    break;
                case "s":
                case "ArrowDown":
                    currentDirection = Direction.Down;
                    break;
            }
        }

        private void MoveSnake()
        {
            (int i, int j) movement = currentDirection switch
            {
                Direction.Down => (1, 0),
                Direction.Up => (-1, 0),
                Direction.Right => (0, 1),
                Direction.Left => (0, -1),
                _ => (0, 0)
            };

            var playedHead = snake[0];
            (int i, int j) newLocation = (playedHead.i + movement.i, playedHead.j + movement.j);

            var currentItem = board[newLocation.i][newLocation.j];
            if (currentItem == BoardState.Food)
            {
                score++;
                board[newLocation.i][newLocation.j] = BoardState.Snake;
                snake.Insert(0, (newLocation.i, newLocation.j));
                PlaceFood();
            }
            else if (currentItem == BoardState.Snake)
            {
                gameOver = true;
                Console.WriteLine("Game over!");
            }
            else
            {
                var lastPosition = snake[0];
                board[snake[0].i][snake[0].j] = null;
                snake[0] = (newLocation.i, newLocation.j);
                board[newLocation.i][newLocation.j] = BoardState.Snake;

                for (var i = 1; i < snake.Count; i++)
                {
                    board[snake[i].i][snake[i].j] = null;
                    (snake[i], lastPosition) = (lastPosition, snake[i]);
                    board[snake[i].i][snake[i].j] = BoardState.Snake;
                }
            }
        }
    }
}