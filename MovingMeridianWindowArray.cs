using System;
using System.Collections.Generic;
using System.Linq;

class MainClass {


      private static List<double> result = new List<double>();
      private static int n =0;
      private static int sw =0;
      private static int[] listOfNumbers {get;set;}

      public static string ArrayChallenge(int[] arr) {

        // code goes here  
      
        sw = arr[0];
        listOfNumbers = new int[arr.Length - 1];
        Array.Copy(arr,1,listOfNumbers,0,arr.Length-1);
        int i =1; 
        while (i < sw)
          {
              result.Add(i);
              i++;
          }
      var currentWindow = GetSlidingWindow(listOfNumbers);
      if(currentWindow!=null)
      {
          result.Add(GetMedianFromCurrentWindow(currentWindow));
      }
       GetNextSlidingWindow();
     
      
      return String.Join(", ", result.ToArray().Skip(1).ToArray());
      }
     private static void GetNextSlidingWindow()
          {
             n++;
            var currentWindow = GetSlidingWindow(listOfNumbers);
            if(currentWindow!=null)
            {
                result.Add(GetMedianFromCurrentWindow(currentWindow));
                GetNextSlidingWindow();
            }
          
     }

    private static int[] GetSlidingWindow(int [] listOfNumbers )
    {
          try{
            var w = new int[sw];
            Array.Copy(listOfNumbers, n, w, 0, sw);
            return w;
          }
          catch {
            return null;
          }
    }
    private static double GetMedianFromCurrentWindow(int[] window){
      
      Array.Sort(window);
      if((window.Length % 2) == 0)
      {
        var i1= window.Length/2;
        var i2 = i1+1;
        return Convert.ToDouble(window[i1-1] + window[i2-1]/2);
      }
      else{
            var i= (window.Length - 1) / 2;
            return window[i];
      }
    }

  static void Main() {  
    // keep this function call here
    Console.WriteLine(ArrayChallenge(Console.ReadLine()));
  } 

}
