// track

while (true)
{
    PrintCubes(GetCubesGameS(5));
    Console.ReadLine();
}

void PrintCubes (string[,] cubes) // Распечать  кубик 
{

    for (int i = 0; i < cubes.GetLength(1) ; i++) // первая  строка
    {
        if(i%3 == 0)
            Console.Write($"-{i/3+1}-");
        else
            Console.Write($"---");
    }

    Console.WriteLine();

    for (int i = 0; i < cubes.GetLength (0); i++)     // сам  кубик 
    {
        for (int j = 0; j < cubes.GetLength (1); j++)
        {
            if (j == 0 || j%3==0 ) // левое  ребро
            {
                Console.Write("|" + cubes[i, j] + " ");
                continue;
            }

            if (j == cubes.GetLength(1) - 1) // правый  край
            {
                Console.Write(" " + cubes[i, j] + "| ");
                continue;
            }

            Console.Write (" " +  cubes [i, j] + " ");   // сам кубик 
        }
        Console.WriteLine();
    }

    for (int i = 0; i < cubes.GetLength(1) * 3; i++) // низ 
        Console.Write("-");

    Console.WriteLine();
}


string[,] GetCubesGameS (int  count) // случайны  кубики 
{

    Random rand = new Random();

    string[,]  cubeStart = GetCubeGame(rand.Next(1, 7));  // первый  кубик 
    if (count == 1)  // если 1 
        return cubeStart;

    for (int i = 0; i < count -1; i++) // 2 кубик  и  далее
    {
        string[,] cubeNew = GetCubeGame(rand.Next (1 , 7 )); // кубик 
        cubeStart = SummaMassivDouble(cubeStart, cubeNew); // добавим  к  первому  
    }
    return cubeStart;

}

string[,] GetCubeGame  ( int  value )  // получить кубик 
{
    switch (value)
    {

        case 1:
          return   new string[,]
            {
               {" " , " " , " "   },
               {" " , "*" , " "   },
               {" " , " " , " "   }
            };
        case 2:
            return new string[,]
           {
               {"*" , " " , " "   },
               {" " , " " , " "   },
               {" " , " " , "*"   }
           };

        case 3:
            return new string[,]
           {
               {"*" , " " , " "   },
               {" " , "*" , " "   },
               {" " , " " , "*"   }
           };

        case 4:
            return new string[,]
           {
               {"*" , " " , "*"   },
               {" " , " " , " "   },
               {"*" , " " , "*"   }
           };

        case 5:
            return new string[,]
           {
               {"*" , " " , "*"   },
               {" " , "*" , " "   },
               {"*" , " " , "*"   }
           };


        case 6:
            return new string[,]
           {
               {"*" , " " , "*"   },
               {"*" , " " , "*"   },
               {"*" , " " , "*"   }
           };

        default: throw new Exception("нет  такого  кубика");
            break;
    }
}


string[,] SummaMassivDouble (string [,]  mas1 ,  string[,]  mas2  ) // сложить  массивы  кубиков  в ряд 
{

    // "*" " " "*"    и     " " " " " "   итог  "*" " " "*" " " " " " "
    // "*" " " "*"          " " "*" " "         "*" " " "*" " " "*" " " 
    // "*" " " "*"          " " " " " "         "*" " " "*" " " " " " "

    string[,] newStrinsg = new string[ mas1.GetLength(0) , mas1.GetLength(1) + mas2.GetLength(1)]; 

    for (int i = 0; i < newStrinsg.GetLength(0 ); i++)
    {
        for (int j = 0; j < newStrinsg.GetLength(1); j++)
        {
            if(j<mas1.GetLength(1) )
            {
                newStrinsg[i, j ] = mas1[i, j];
            }
            else
            {
                newStrinsg[i, j] = mas2[i, j - mas1.GetLength(1)];
            }
        }
    }
    return newStrinsg;
}