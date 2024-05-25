// See https://aka.ms/new-console-template for more information
using EspacioTarea;
Console.WriteLine("Hello, World!");

var tarea= new Tarea(1, "tarea 1", 10);

var tareasPendientes=new List<Tarea>();
tareasPendientes.Add(tarea);

var tareasRealizadas=new List<Tarea>();

Random rnd = new Random();
Random rndDescrip=new Random();


string[] Descrip = {"Desarrollo", "Pruebas", "Soporte tecnico", "Maquetacion", "Algoritmos"};
int duracion = rnd.Next(10,101);
for(int i=0; i< Descrip.Length; i++){
    tarea=new Tarea(i, Descrip[rndDescrip.Next(Descrip.Length)], rnd.Next(10,101));
    Console.WriteLine($"----------Tarea {i+1}------------");
    Console.WriteLine($"ID: {tarea.Id}");
    Console.WriteLine($"Descripcion: {tarea.Descripcion}");
    Console.WriteLine($"Duracion: {tarea.Duracion}");
     
}





