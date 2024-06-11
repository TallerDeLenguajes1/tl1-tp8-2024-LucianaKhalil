// See https://aka.ms/new-console-template for more information
using System;
using EspacioTarea;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var tareasPendientes = new List<Tarea>();
            var tareasRealizadas = new List<Tarea>();

            Random rnd = new Random();
            string[] Descrip = { "Desarrollo", "Pruebas", "Soporte tecnico", "Maquetacion", "Algoritmos" };

            // Generar tareas aleatorias y agregar a tareasPendientes
            for (int i = 0; i < Descrip.Length; i++)
            {
                var tarea = new Tarea(i, Descrip[rnd.Next(Descrip.Length)], rnd.Next(10, 101));
                tareasPendientes.Add(tarea);
                Console.WriteLine($"----------Tarea {i+1}------------");
                Console.WriteLine($"ID: {tarea.Id}");
                Console.WriteLine($"Descripcion: {tarea.Descripcion}");
                Console.WriteLine($"Duracion: {tarea.Duracion}");
            }

            // Mostrar tareas pendientes y realizar la operación de mover tarea
            MostrarTareas(tareasPendientes, "Pendientes");
            MoverTarea(tareasPendientes, tareasRealizadas);
            MostrarTareas(tareasRealizadas, "Realizadas");
            MostrarTareas(tareasPendientes, "Pendientes");
            BuscarDescripcion(tareasPendientes);
        }
/****************************************FUNCIONES************************************************/
        static void MostrarTareas(List<Tarea> tareas, string estado)
        {
            Console.WriteLine($"\n--- Tareas {estado} ---");
            if (tareas.Count == 0)
            {
                Console.WriteLine($"No hay tareas {estado.ToLower()}.");
                return;
            }

            foreach (var tarea in tareas)
            {
                Console.WriteLine($"ID: {tarea.Id}");
                Console.WriteLine($"Descripción: {tarea.Descripcion}");
                Console.WriteLine($"Duración: {tarea.Duracion}");
                Console.WriteLine("---------------------------");
            }
        }

        static void MoverTarea(List<Tarea> pendientes, List<Tarea> realizadas)
        {
            if (pendientes.Count == 0)
            {
                Console.WriteLine("No hay tareas pendientes para mover.");
                return;
            }

            Console.Write("Ingrese el ID de la tarea a mover: ");
            int id = int.Parse(Console.ReadLine());

            Tarea tareaAMover = null;
            foreach (var tareaPendiente in pendientes)
            {
                if (tareaPendiente.Id == id)
                {
                    tareaAMover = tareaPendiente;
                    break;
                }
            }
            if (tareaAMover == null)
            {
                Console.WriteLine("Tarea no encontrada.");
                return;
            }

            pendientes.Remove(tareaAMover);
            realizadas.Add(tareaAMover);
            Console.WriteLine("Tarea movida exitosamente.");
        }
        static void BuscarDescripcion(List<Tarea> pendientes){
            Console.WriteLine("Ingrese una descripcion para buscar");
            string descripciones=Console.ReadLine().ToLower();
            var tareasEncontradas=new List<Tarea>();
            foreach(var tarea in pendientes){
                if(tarea.Descripcion.ToLower().Contains(descripciones)){
                    tareasEncontradas.Add(tarea);
                }
            }
            if (tareasEncontradas.Count == 0)//si no hay tareas encontrada
            {
                Console.WriteLine("No se encontraron tareas con esa descripción.");
            }
            else
            {
                MostrarTareas(tareasEncontradas, "Encontradas");
            }
        }

    }
   