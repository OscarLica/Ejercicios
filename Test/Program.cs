using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    public class Flechas
    {
        public string flecha { get; set; }
        public int direccion { get; set; }

    }
    class Program
    {
        public enum EFlechas
        {
            derecha = 1,
            izquierda = 2,
            abajo = 3,
            arriba = 4
        }
        public enum dias
        {
            Mon = 1, // lunes
            Tue = 2, // martes
            Wed = 3, // miercoles
            Thu = 4, // jueves
            Fri = 5, // viernes
            Sat = 6, // sabado
            Sun = 7  // domingo
        }
        public static int[] elements = new int[] { -1, -3 };//2,4
        static void Main(string[] args)
        {
            //AgrupacionBilletes();
            RotarFlechas();
        }

        /// <summary>
        ///  Rotar flechas
        /// </summary>
        public static void RotarFlechas()
        {

            List<string> comandos = new List<string>() { "v", "^", "<", ">" };

            Console.WriteLine("Cuantas flechas va ingresar");
            int cantidadFlechas = int.Parse(Console.ReadLine());

            List<Flechas> flechas = new List<Flechas>();

            int cantidadprocesadas = 0;
            while (cantidadFlechas != cantidadprocesadas)
            {
                Console.WriteLine("Ingrese la flecha");
                var flecha = Console.ReadLine();
                if (!comandos.Any(x => x == flecha.Trim()))
                {
                    Console.WriteLine("Comando no valido");
                }
                else
                {
                    switch (flecha.Trim())
                    {
                        case ">":
                            flechas.Add(new Flechas { flecha = flecha, direccion = (int)EFlechas.derecha });
                            break;
                        case "<":
                            flechas.Add(new Flechas { flecha = flecha, direccion = (int)EFlechas.izquierda });
                            break;
                        case "v":
                            flechas.Add(new Flechas { flecha = flecha, direccion = (int)EFlechas.abajo });
                            break;
                        case "^":
                            flechas.Add(new Flechas { flecha = flecha, direccion = (int)EFlechas.arriba });
                            break;
                    }
                    cantidadprocesadas++;
                }


            }

            var grupos = flechas.GroupBy(x => x.direccion).Select(y => new { d = y.Count() });
            var minimo = 0;

            var suma = grupos.ToList().Sum(x => x.d);
            if (suma == cantidadFlechas)
            {
                minimo = grupos.Sum(x => x.d) - grupos.FirstOrDefault().d;
            }
            else
            {

                int mayor = 0;
                grupos.ToList().ForEach(g =>
                {
                    mayor = mayor < g.d ? g.d : mayor;
                });

                var soloMenores = grupos.Where(x => x.d != mayor).ToList();
                minimo = soloMenores.Sum(x => x.d);
            }

            Console.WriteLine($"Cantidad de flechas para que todas esten en la misma dirección :" +
                $" { minimo}");

        }

        /// <summary>
        ///     dado un día de la semana y un entero suma los días y devuelve el día de la semana
        /// </summary>
        public static void DiasSemana()
        {
            List<dias> dSemanas = new List<dias>
            { dias.Mon, dias.Tue, dias.Wed, dias.Thu, dias.Fri, dias.Sat, dias.Sun};

            Console.WriteLine("Ingrese el día de la semana");
            string dia = Console.ReadLine();
            dias diaIngresado = (dias)Enum.Parse(typeof(dias), dia, true);

            Console.WriteLine("Ingrese los días a sumar");
            int diaSuma = int.Parse(Console.ReadLine());

            var dsem = dSemanas.FirstOrDefault(x => x == diaIngresado);
            int disresultante = (int)dsem;
            for (int i = (int)dias.Mon; i < diaSuma; i++)
            {
                disresultante += 1;

                if (disresultante == (int)dias.Sun)
                    disresultante = (int)dias.Mon;
            }

            Console.WriteLine($"Día resultante {(dias)disresultante}");

        }

        /// <summary>
        ///     Encuentra el número mayor
        /// </summary>
        public static void MayorDeNumeros()
        {
            List<int> numeros = new List<int>();
            int cantidad = 0;
            Console.WriteLine("Cuantos números desea compara : ");
            cantidad = int.Parse(Console.ReadLine());
            for (int i = 0; i < cantidad; i++)
            {
                int numero = 0;
                Console.WriteLine($"Ingrese el valor {i}: ");
                numero = int.Parse(Console.ReadLine());
                numeros.Add(numero);
            }

            Console.WriteLine($"El número mayor es : {numeros.Distinct().Max()}");
        }
        public static void FactorialNumero()
        {

            Console.WriteLine("Ingrese el número");
            int numero = int.Parse(Console.ReadLine());
            int numeroTemp = numero;
            int resultado = 1;
            for (int i = 2; i <= numeroTemp; i++)
            {
                resultado = resultado * i;
            }
            Console.WriteLine($"El número factorial de {numeroTemp} es : { resultado}");
        }

        /// <summary>
        ///     Tabla de mutplicar
        /// </summary>
        public static void TablaDeMultiplicar()
        {
            Console.WriteLine("Ingrese la tabla de multiplicar que desea prácticar");
            int tablaMultplicar = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese hasta que valor desea multiplicarlo");
            int valorMultiplicacion = int.Parse(Console.ReadLine());

            for (int i = 1; i <= valorMultiplicacion; i++)
            {
                Console.WriteLine($"{tablaMultplicar} x {i}");
                int respuesta = int.Parse(Console.ReadLine());
                var resultado = respuesta == (tablaMultplicar * i) ? $"Correcto la respuesta es : {(tablaMultplicar * i)}" : $"Respuesta incorrecta, la respuesta es : {(tablaMultplicar * i)}";
                Console.WriteLine(resultado);

            }
        }

        /// <summary>
        ///     Agrupa los billetes de un pago en denominaciones
        /// </summary>
        public static void AgrupacionBilletes()
        {
            List<int> denomiacionesPermitidas = new List<int> { 10, 20, 50, 100, 200, 500 };
            Console.WriteLine("Ingrese la cantidad a pagar");
            int cantidadPagar = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese los billetes, solo se aceptan denominaciones de 10,20,50,100,200,500");
            List<int> billetes = new List<int>();
            while (cantidadPagar != billetes.Sum(x => x))
            {
                Console.WriteLine($"Saldo : {cantidadPagar - billetes.Sum(x => x)}");
                Console.WriteLine("Ingrese el monto del billete");
                int billete = int.Parse(Console.ReadLine());
                if (!denomiacionesPermitidas.Any(x => x == billete))
                    Console.WriteLine("Denominación de billete no valida");
                else
                    billetes.Add(billete);
            }

            billetes.GroupBy(x => x).ToList().ForEach(x => { Console.WriteLine($"Demoninación : { x.Key } - cantidad {x.Count()}"); });
        }


        /// <summary>
        ///     Devuelve en número entero positivo que no está dentro del array de enteros 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int Solucion(int[] array)
        {
            int np = 1;

            var enteros = array.Where(x => x > 0).Distinct().OrderBy(n => n).ToList();

            foreach (var entero in enteros)
            {
                var result = entero + 1;

                if (!enteros.Any(x => x == result))
                {
                    np = result;
                    break;
                }
            }

            return np;
        }
    }
}
