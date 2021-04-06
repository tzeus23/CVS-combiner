/**********************************************************************/
/*                                                                    */
/* Program Name: CSV combiner - A take home program for PMG           */
/* Author:       Tzuriel Azodoh                                       */
/* Langiage:     C#                                                   */
/* Date Written: April 3, 2021                                        */
/*                                                                    */
/**********************************************************************/

/**********************************************************************/
/*                                                                    */
/* This program takes csv files from a fixture folder and combines    */
/* them into one csv folder called 'combined.csv' found in the        */
/* csv-combiner folder.                                               */
/*                                                                    */
/**********************************************************************/

using System;
using System.Data;
using System.IO;
using System.Linq;

namespace csv_combiner
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceFolder = @"C:\Users\tzuri\Desktop\csv-combiner\fixtures";       //Source folder for the files to be mergerd.
            string destinationFile = @"\Users\tzuri\Desktop\csv-combiner\combined.csv";  //The destination file for the merging.
            string[] filePaths = Directory.GetFiles(sourceFolder);                       //Stores the file path for each file
            StreamWriter fileDest = new StreamWriter(destinationFile, true);             //Writes to the destination file

            //Loops through the files in the fixtures folder till all files are merged
            for (int i = 0; i < filePaths.Length; i++)
            {
                string file = filePaths[i];                       //Points to each file
                string[] lines = File.ReadAllLines(file);         //An array of lines in each file
                string fileName = Path.GetFileName(filePaths[i]); //Gets the filename of each file

                // Skip header row for all but first file
                if (i > 0)
                {
                    lines = lines.Skip(1).ToArray();
                }

                //Loops through each line of code until all lines are read
                for(int j = 0; j < lines.Length; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        fileDest.WriteLine(lines[0] += "," + "File name");
                    }
                    else
                    {
                        fileDest.WriteLine(lines[j] += "," + fileName);
                    }    
                }
            }

            fileDest.Close(); //closes the file

        }
    }
}
