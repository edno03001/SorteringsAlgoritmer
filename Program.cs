using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;


namespace SorteringsAlgoritmer
{
    class Program
    {
        //metod för Bubblesort
        static void Bubblesort(List<int> myList)
        {
            for (int i = 0; i < myList.Count; i++) //nested for loop
            {
                for (int j = 0; j < myList.Count - 1; j++)
                {
                    if (myList[j] > myList[j + 1]) //jämför exempelvis den femte och det sjätte elementet ifall j=5
                    {
                        int temp = myList[j]; 
                        myList[j] = myList[j + 1];
                        myList[j + 1] = temp;
                    }
                }
            }

        }

    

        //metod för Selectionsort
        static void Selectionsort(List<int> myList)
        {

            int temp, min; //deklarerar två variabler. min är det element med lägst värde temp är det temporära som jämförs
            for (int i = 0; i < myList.Count-1; i++)
            {
                min = i; //lägsta värdet är lika med det nuvarande elementet
                for(int j=i+1;j<myList.Count;j++)
                {
                    if(myList[j]<myList[min])
                    {
                        min = j;
                    }
                }

                if(myList[min]!=myList[i])
                {
                    temp = myList[min];
                    myList[i] = temp;
                    myList[min] = myList[i];

                }
                

                
            }

        }

        private static List<int> MergeSort(List<int> osorterad)
        {
          
            if (osorterad.Count <= 1)
                return osorterad;
            
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = osorterad.Count / 2;

            for (int i=0;i<middle;i++)
            {
                left.Add(osorterad[i]);
            }
            for(int i =middle;i<osorterad.Count;i++)
            {
                right.Add(osorterad[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> resultat = new List<int>();
            while(left.Count>0 || right.Count>0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First()) //jämför de första två elementen för att se vilken som är minst
                    {
                        resultat.Add(left.First());
                        left.RemoveAt(0); //resten av listan minus det första elementet
                    }
                    else
                    {
                        resultat.Add(right.First());
                        right.RemoveAt(0);
                    }

                }
                else if (left.Count > 0)
                {
                    resultat.Add(left.First());
                    left.RemoveAt(0);
                }
                else if (right.Count>0)
                {
                    resultat.Add(right.First());
                    right.RemoveAt(0);
                }
            }
            return resultat;
        }

        static int Partition(List<int> data, int low, int high)
        {
            int pivot = data[high];

            int lowIndex = (low - 1);

            for(int j = low; j < high ; j++)
            {
                if (data[j] <=pivot)
                {
                    lowIndex++;

                    int temp = data[lowIndex];
                    data[lowIndex] = data[j];
                    data[j] = temp;
                }
            }

            int temp1 = data[lowIndex + 1];
            data[lowIndex + 1] = data[high];
            data[high] = temp1;

            return lowIndex + 1;


        }

        static void Quicksort(List<int> lista,int low,int high)
        {
            if(low<high)
            {
                int partitionIndex = Partition(lista, low, high);

                Quicksort(lista, low, partitionIndex - 1);
                Quicksort(lista, partitionIndex + 1, high);
            }
        }

        //metod för att generera en lista med slumpmässiga element
        //variabeln antal får värde i main metoden
        static void SkapaLista(List<int> list, int antal)
        {
            Random r = new Random();
            for (int i = 0; i < antal; i++)
            {
                list.Add(r.Next(5000));
            }
        }


        static void Main(string[] args)
        {
            //skapar en ny lista och testar hur lång tid det tar för algoritmen att sortera
            for(int i = 0; i<5;i++)
            {
                //skapar en lista som heter tallista
                List<int> osorterad = new List<int>();

                SkapaLista(osorterad, 128000); //tallistan får ett antal st. element

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                //Quicksort(osorterad,0,osorterad.Count-1); 
                //MergeSort(osorterad);
                //Selectionsort(osorterad);
                //Bubblesort(osorterad);
                stopWatch.Stop();

                //Console.WriteLine("Bubblesort: " + stopWatchB.Elapsed + "ms" + " ");
                //Console.WriteLine("Selectionsort: " + stopWatchS.ElapsedMilliseconds + "ms" + " ");
                Console.WriteLine("tid: " + stopWatch.ElapsedMilliseconds + "ms");
            }
           
        }

    }
}
