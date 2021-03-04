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
            for(int i =0;i<osorterad.Count;i++)
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
                        left.RemoveAt(0);
                        //left.Remove(left.First()); //resten av listan minus det första elementet
                    }
                    else
                    {
                        resultat.Add(right.First());
                        right.RemoveAt(0);
                        //right.Remove(right.First());
                    }

                }
                else if (left.Count > 0)
                {
                    resultat.Add(left.First());
                    left.RemoveAt(0);
                    //left.Remove(left.First());
                }
                else if (right.Count>0)
                {
                    resultat.Add(right.First());
                    right.RemoveAt(0);
                    //right.Remove(right.First());
                }
            }
            return resultat;
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

            //skapar en lista som heter tallista
            List<int> osorterad = new List<int>();
            List<int> sorterad;

            SkapaLista(osorterad, 10); //tallistan får ett antal st. element


           


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            MergeSort(osorterad);  
            stopWatch.Stop();

            //Console.WriteLine("Bubblesort: " + stopWatchB.Elapsed + "ms" + " ");
            //Console.WriteLine("Selectionsort: " + stopWatchS.ElapsedMilliseconds + "ms" + " ");
            Console.WriteLine("Mergesort: " + stopWatch.ElapsedMilliseconds + "ms");
        }

    }
}
