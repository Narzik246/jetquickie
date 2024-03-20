
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("where text file? ");
            Console.WriteLine("\nPls put specific location of the txt file and the \".txt\" at the end.\nTo find the exact file location \nright click the .txt file then click \"Properties\" usually found at the bottom then click it." +
                "\nLook for the \"location\" then copy the written address then add the name of the .txt file.\n eg. C:\\Users\\jonathanthewhale\\Downloads\\DearJohn.txt");
            string fileName = Console.ReadLine();
            ReadTextFile(fileName);

            Console.Write("\nWhere would you like ur print? Pls put specific location. And the name for your .txt file breakdown :3" +
                "\nIf you want to put it at the same place on where you got your .txt file at\nJust do the same thing as last time and add what you want to name the breakdown .txt file ");
            string outputPath = Console.ReadLine();
            StreamWrite(fileName, outputPath);

            Console.WriteLine("\nHere's your receipt sir! Thank you and come again! uwu");
            Console.ReadKey();
        }

        static void ReadTextFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                string content = reader.ReadToEnd();
                string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t', '.', '!', '?', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                int wordCount = words.Length;
                int sentenceCount = content.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;

                Console.WriteLine($"\nHow many words you got in the whole text file? Just around = {wordCount}");
                Console.WriteLine($"How many sentences you may ask? We got that too 😎 = {sentenceCount}");
                Console.WriteLine("\nNow you want to count how many each word popped up?? thats crazy anyways here is the breakdown of each unique words");
                foreach (string word in words)
                {
                    int count = 0;
                    foreach (string w in words)
                    {
                        if (word.ToLower() == w.ToLower())
                            count++;
                    }
                    Console.WriteLine($"{word} = {count} ");
                }
            }
        }

        static void StreamWrite(string inputFileName, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                using (StreamReader reader = new StreamReader(inputFileName))
                {
                    string content = reader.ReadToEnd();
                    string[] words = content.Split(new char[] { ' ', '\n', '\r', '\t', '.', '!', '?', '(', ')', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    int wordCount = words.Length;
                    int sentenceCount = content.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;

                    writer.WriteLine($"Number of words in the file: {wordCount}");
                    writer.WriteLine($"Number of sentences in the file: {sentenceCount}");
                    writer.WriteLine("\nWord count breakdown:");
                    foreach (string word in words)
                    {
                        int count = 0;
                        foreach (string w in words)
                        {
                            if (word.ToLower() == w.ToLower())
                                count++;
                        }
                        writer.WriteLine($"{word} = {count} ");
                    }
                }
            }
        }
    }
}