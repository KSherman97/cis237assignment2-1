// Kyle Sherman
// 2/8/2017

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace cis237assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        /// <summary>
        /// Class level memeber variable for the mazesolver class
        /// </summary>
        char[,] maze;
        int xStart;
        int yStart;
        int mazeSize;
        bool mazeSolved;
        int steps = 0;

        /// <summary>
        /// Default Constuctor to setup a new maze solver.
        /// </summary>
        public MazeSolver()
        {}
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            //Assign passed in variables to the class level ones. It was not done in the constuctor so that
            //a new maze could be passed in to this solve method without having to create a new instance.
            //The variables are assigned so they can be used anywhere they are needed within this class. 
            this.maze = maze;
            this.xStart = xStart;
            this.yStart = yStart;
            mazeSolved = false;
            steps = 0;

            //printMaze();
            //Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// </summary>
        private void mazeTraversal(int xPosition, int yPosition)
        {
            this.mazeSize = maze.GetLength(0)-1; // mazeSize is the arraylength - 1

            maze[xPosition, yPosition] = 'x'; // replace the current index with an x
           
            if (!mazeSolved) // see if the maze has been solved
            {
                printMaze();    // output the maze
                if (xPosition >= mazeSize || xPosition <= -1 || yPosition >= mazeSize || yPosition <= -1) // see if the index out of inbounds
                {
                    mazeSolved = true;      // set mazesolved to true

                    // output the number of steps it took to solve
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(Environment.NewLine + "Maze solved in {0} steps", steps);
                    Console.ResetColor();
                }
                else
                {
                    if (maze[xPosition, yPosition + 1] == '.') // check above the current index to see if it's a valid spot to move
                    {
                        mazeTraversal(xPosition, yPosition + 1);
                        //Console.WriteLine("MoveRight");
                    }
                    if (maze[xPosition - 1, yPosition] == '.') // check to the left of the current index to see if it's a valid spot to move
                    {
                        mazeTraversal(xPosition - 1, yPosition);
                        //Console.WriteLine("MoveDown");
                    }
                    if (maze[xPosition + 1, yPosition] == '.') // check to the right of the current index to see if it's a valid spot to move
                    {
                        mazeTraversal(xPosition + 1, yPosition);
                        //Console.WriteLine("MoveUp");
                    }
                    if (maze[xPosition, yPosition - 1] == '.') // check below the current index to see if it's a valid spot to move
                    {
                        mazeTraversal(xPosition, yPosition - 1);
                        //Console.WriteLine("MoveLeft");
                    }
                    if (!mazeSolved)  // check to see if the maze is solved 
                    {
                        maze[xPosition, yPosition] = '0' ;  // replace the current index with a 0
                        printMaze(); // print the maze
                    }
                }
            }
        }

        private void printMaze()
        {
            Thread.Sleep(150); // wait 150 ms
            Console.Clear();    // clear the console window 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Solving Maze." + Environment.NewLine + "Step: " + ++steps + Environment.NewLine); // output the solving maze text
            Console.ResetColor();

            int xPosition, yPosition;


            for (xPosition = 0; xPosition < maze.GetLength(0); xPosition++) // for loop to increment the x position
            {
                for (yPosition = 0; yPosition < maze.GetLength(0); yPosition++) // for loop to increment the y position
                {
                    if (maze[xPosition, yPosition] == 'x')              // check to see if the current index is an x
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    if (maze[xPosition, yPosition] == '0')              // check to see if the current index is a 0
                        Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("{0}", maze[xPosition, yPosition]);   // output the current index of the maze
                    Console.ResetColor();
                }
                Console.WriteLine(); // put a new line after each y position
            }
        }
    }
}