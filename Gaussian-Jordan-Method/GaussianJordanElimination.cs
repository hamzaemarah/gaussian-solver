using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;


namespace ConsoleApplication6
{
    class GaussianJordanElimination
    {
        double[,] a;
        int rows;
        public GaussianJordanElimination() { 
        }
       public void setArray(double [,]arr){
       this.a=arr;
        this.rows=arr.GetLength(0);
       }

        public void printMatrix(double[,]mat) {
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j]+"\t");
                }
                Console.WriteLine();
            }
        }

        public string matToString(double[,] mat)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    //Console.Write(mat[i, j] + "\t");
                    sb.Append(mat[i, j] + "  ");
                }
                Console.WriteLine();
                sb.Append("\n");
            }
            sb.Append("\n");
            return sb.ToString();

        }

        public string solve()
        {
            rows = a.GetLength(0);
            int cols = a.GetLength(1);
            StringBuilder sb = new StringBuilder();

            Console.WriteLine("Displaying input Matrix");
            printMatrix(a);
            sb.Append("Displaying input Matrix \n");
            sb.Append(matToString(a));


            for (int i = 0; i < rows; i++)      // i representing no of rows
            {
                double temp = a[i, i];
                
                //this for loop to make the first element equals 1
                for (int j = 0; j < cols; j++)    // j representing no of columns
                {
                    a[i, j] = a[i, j] / temp;  // To Store Multipliers
                }
                Console.WriteLine("Row operation is row" + i + " is divided by " + temp);
                printMatrix(a);
                sb.Append("Row operation is row" + i + " is divided by " + temp+" \n");
                sb.Append(matToString(a));

                for (int k = 0; k < rows; k++)  // k representing Rows on which operation is
                {                               // being performed. To create zeros below &////apply row operation for every row
                    temp = a[k, i]; // above the main diagonal.
                    if (i != k)
                    {
                        for (int j = 0; j < cols; j++) // j represents no of colums on which operation is being performed

                        {
                            a[k, j] = a[k, j] - (temp * a[i, j]);
                        }
                        Console.WriteLine("Row operation  is row" + i + " is multiplied by " + temp + " and then subtarcted from row" + k);
                        printMatrix(a);
                        sb.Append("Row operation  is row" + i + " is multiplied by " + temp + " and then subtarcted from row" + k+" \n");
                        sb.Append(matToString(a));

                    }
                }
               // printMatrix(a);
            }

            Console.WriteLine("solved matrix");
            printMatrix(a);
            sb.Append("solved matrix \n");
            sb.Append(matToString(a));

            return sb.ToString(); 

        }

        public static double DET(int n, double[,] Mat)
        {
            double d = 0;
            int k, i, j, subi, subj;
            double[,] SUBMat = new double[n, n];

            if (n == 2)
            {
                return ((Mat[0, 0] * Mat[1, 1]) - (Mat[1, 0] * Mat[0, 1]));
            }

            else
            {
                for (k = 0; k < n; k++)
                {
                    subi = 0;
                    for (i = 1; i < n; i++)
                    {
                        subj = 0;
                        for (j = 0; j < n; j++)
                        {
                            if (j == k)
                            {
                                continue;
                            }
                            SUBMat[subi, subj] = Mat[i, j];
                            subj++;
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * Mat[0, k] * DET(n - 1, SUBMat));
                }
            }
            return d;
        }


    }

   
   
    
}