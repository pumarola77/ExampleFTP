using System;
using System.IO;

namespace ExampleFTP
{
    class TractamentDELNOT
    {
        public static void LecturaDELNOT(String path)
        {
            char delimiter = ',';
            
            string[] lines = File.ReadAllLines(path);

            foreach (string line in lines)
            {       
                // Parteix la linia per el delimitador.
                String[] substrings = line.Split(delimiter);

                //Console.WriteLine(substrings.Length);

                foreach (var substring in substrings)
                 {
                    Console.WriteLine(substring);    
                 }
                Console.WriteLine("#########################");
            }

            // Un cop recollits els valors faria falta el insert
            // a la taula.
        }
    }
}
