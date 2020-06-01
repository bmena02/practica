using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using XSoluciones.Properties;
using System.Data;

namespace XSoluciones
{
    class Program
    {
        static IEmpleadoRepositorio empleadoRepositorio = new EmpleadoRepositorio();
        public static void Main(string[] args)
        {

            //string nombre = Console.ReadLine();

            // var resultado = empleadoRepositorio.Create(new Empleado() { Nombre = nombre });

            //Console.WriteLine(resultado.Result);


            /*OperationResult empleados = empleadoRepositorio.GetAll();

            if (!empleados.Result)
            {
                Console.WriteLine(empleados.Message);
            }
            else
            {
                DataTable dataEmpleados = (DataTable)empleados.Data;

                foreach (DataRow emp in dataEmpleados.Rows)
                {
                    Console.WriteLine($"Su nombre de suplidor es: {emp["ID_Suplidor"]} {emp["Nombre"]} {emp["RNC"]} {emp["Representante"]} {emp["Direccion"]} {emp["FechadeRegistro"]}");
                }
            }*/

            int idEmpleado;

            int opcion2 = 0;

            Console.Clear();
            Console.WriteLine($"                                                                {DateTime.Now.ToString()}\n");
            Console.WriteLine("                                     Empresa XSoluciones                                     \n");


            Console.WriteLine("                                       Menú de opciones                                        \n");
            Console.WriteLine("\n1-) Crear Suplidor");
            Console.WriteLine("\n2-) Generar reporte de los Suplidores");
            Console.WriteLine("\n3-) Buscar Suplidor");
            Console.WriteLine("\n4-) Borrar Suplidor");
            Console.WriteLine("\n5-) Salir del programa\n");

            opcion2 = Convert.ToInt32(Console.ReadLine());

            switch(opcion2)
            {
                case 1:
                    {
                        Console.WriteLine("Agregar ID de Suplidor: ");
                        Console.WriteLine("Agregar nombre: ");
                        Console.WriteLine("Agregar RNC: ");
                        Console.WriteLine("Agregar representante: ");
                        Console.WriteLine("Agregar Dirección: ");
                        Console.WriteLine("Agregar Fecha de Registro: ");
                    }break;
                case 2:
                    {
                        Console.WriteLine("Reporte que desea generar: ");
                    }break;
                case 3:
                    {
                        Console.WriteLine("Suplidor que desea buscar: ");
                    }break;
                case 4:
                    {
                        Console.WriteLine("Suplidor que desea borrar");
                    }break;
                case 5:
                    {
                        Console.WriteLine("Opcion de salir");
                    }break;
                default:
                    Console.WriteLine("No ha seleccionado ninguna opción");
                    break;
            }

            Console.ReadKey();

            //Console.Write("Digite el ID de empleado que desea buscar: ");

            while (!int.TryParse(Console.ReadLine(), out idEmpleado))
            {
                Console.Write("Su ID no existe por favor digite un ID correcto: ");
            }

            OperationResult empleados = empleadoRepositorio.FindById(idEmpleado);

               if (!empleados.Result)
            {
               Console.WriteLine(empleados.Message);
            }
            else
            {
                DataTable dataEmpleado = (DataTable)empleados.Data;

                foreach (DataRow emp in dataEmpleado.Rows)
                {
                    Console.WriteLine($"Su nombre de suplidor es: {emp["ID_Suplidor"]} {emp["Nombre"]} {emp["RNC"]} {emp["Representante"]} {emp["Direccion"]} {emp["FechadeRegistro"]}");
                }

                /*Console.WriteLine("Digite el nuevo nombre del suplidor: ");
                var nuevoNombre = Console.ReadLine();

                var actualizar = empleadoRepositorio.Update(new Empleado() { Nombre = nuevoNombre}, idEmpleado);
                Console.WriteLine(actualizar.Message);*/

                Console.WriteLine("Desea borrar el empleado? ");

                var opcion = Console.Read();

                if (opcion.ToString() == "s") 
                {
                    var borrar = empleadoRepositorio.SoftDelete(idEmpleado);

                    Console.WriteLine(borrar.Message);
                }
            }

            Console.Read();
        }
    }
}
