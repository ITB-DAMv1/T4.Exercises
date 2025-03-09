using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.ConstrainedExecution;
using T4.Activitats;
using T4.Activities.Tools;

internal class Program
{
    public static void Main(string[] args)
    {

        Console.WriteLine("********** T4.Activitats **********");

        //Ex1();
        //Ex2();
        Ex5();
        Ex6();

    }
    public static void Ex1()
    {
        Console.WriteLine("*** T4.1");
        Pair<string, int> pair1 = new Pair<string, int>("Hola", 3);

        Console.WriteLine("Pair1 {0}", pair1.ToString());


        Pair<double, bool> pair2 = new Pair<double, bool>(3.5d, false);

        Console.WriteLine("Pair2 {0}", pair1.ToString());
    }

    public static void Ex2()
    {
        const string extiInput = "0Exit";
        string s;
        Console.WriteLine("*** T4.2");

        ArrayList arrayList = new ArrayList();

        Console.WriteLine("Afegeix valors al ArrayList. Per finalitzar escriu: {0}", extiInput);
        do
        {
            s = Console.ReadLine();
            arrayList.Add(s);
        } while (!string.Equals(s, extiInput) && s != "");

        foreach (var item in arrayList)
        {
            Console.WriteLine(item);
        }
    }
    public static void Ex3()
    {
        const string extiInput = "0Exit";
        Console.WriteLine("*** T4.3");
        Dictionary<string, int> edats = new Dictionary<string, int>();
        string s;
        do
        {
            Console.WriteLine("Escriu Nom simple i edat separats per ','");
            s = Console.ReadLine();
            var sArray = s.Split(",");
            if (sArray.Length < 2 && !string.Equals(s, extiInput))
            {
                Console.WriteLine("Error de dades");
            }

        } while (!string.Equals(s, extiInput));
    }
	/// <summary>
	/// Exercice 5: Troba els nombres parells en una llista d'enters introduïts per teclat i mostra’ls per consola.
	/// </summary>
	public static void Ex5()
	{
		const string extiInput = "0Exit";
		Console.WriteLine("*** T4.5");
		Console.WriteLine("Introdueix una llista de nombres enters separats per espais:");
		string entrada = Console.ReadLine(); // Llegim l'entrada com a string

		// Convertim l'entrada en una llista d'enters
		List<int> nombres = entrada.Split(' ')
								   .Where(s => int.TryParse(s, out _)) // Filtra només els enters vàlids
								   .Select(int.Parse)
								   .ToList();

		// Filtrar nombres parells
		IEnumerable<int> parells = nombres.Where(n => n % 2 == 0).ToList();

		// Mostrar el resultat
		Console.WriteLine("Nombres parells:");
		Console.WriteLine(string.Join(", ", parells));

        //Console.WriteLine(parells.ElementAt<int>(0)); --> estara buida! Si vull treballar un altre cop, aquest IEnumarable ha de convertir-se en llista.

	}

	/// <summary>
	/// Calcula quants dies falten per a una data específica introduïda per teclat i mostra el resultat per consola .
	/// </summary>
	public static void Ex6()
    {
        DateTime dT;
        DateTime today = DateTime.Today;
        bool dateCorrect = false;
        IFormatProvider provider = CultureInfo.CurrentCulture;
        do
        {
            Console.WriteLine("Introdueix data dd/mm/yyyy");
            dateCorrect = DateTime.TryParse(Console.ReadLine(), provider, out dT);
            if (!dateCorrect) Console.WriteLine("Error de format");
            else
            {
                TimeSpan diferencia = dT - today;
                if (diferencia.Days < 0) 
                    Console.WriteLine("La data ja ha pasat");
                else
                    Console.WriteLine("Diferencia de dies: {0}", diferencia.Days);
            }
        } while (!dateCorrect);
    }

	/// <summary>
	///     Crea un programa que faci el següent:
    ///         Declari un ArrayList i hi afegeixi els següents elements: "Maria", "Joan", "Anna", 42, true.
    ///         Mostri tots els elements a la consola.
    ///         Elimini el número 42 i el valor true.
    ///         Insereixi "Pere" a la segona posició.
    ///         Comprovi si "Anna" està a la llista.
    ///         Converteixi l'ArrayList a un string[].
	/// </summary>
	public static void Ex7() {
		// 1️ Declarar un ArrayList i afegir elements
		ArrayList llista = new ArrayList { "Maria", "Joan", "Anna", 42, true };

		// 2️ Mostrar tots els elements
		Console.WriteLine("Llista original:");
		CollectionTools.PrintCollection(llista);

		// 3️ Eliminar el número 42 i el valor true
		llista.Remove(42);
		llista.Remove(true);
		Console.WriteLine("\nDesprés d'eliminar 42 i true:");
		CollectionTools.PrintCollection(llista);

		// 4️ Inserir "Pere" a la segona posició (índex 1)
		llista.Insert(1, "Pere");
		Console.WriteLine("\nDesprés d'inserir 'Pere' a la segona posició:");
		CollectionTools.PrintCollection(llista);

		// 5️ Comprovar si "Anna" està a la llista
		bool contéAnna = llista.Contains("Anna");
		Console.WriteLine($"\nLa llista conté 'Anna'? {contéAnna}");

		// 6️ Convertir l'ArrayList a un string[]
		string[] array = llista.OfType<string>().ToArray();
		Console.WriteLine("\nArray de strings convertit:");
		Console.WriteLine(string.Join(", ", array));
	}

	/// <summary>
	/// Crea un programa que:
	///     Declari una List<int> amb els números[5, 10, 15, 20, 25].
    ///     Afegeixi 30 al final de la llista.
    ///     Insereixi 7 a la primera posició.
    ///     Elimini el número 15.
    ///     Ordeni la llista en ordre descendent.
    ///     Filtri els nombres parells i els mostri per pantalla
	/// </summary>
	public static void Ex8()
    {
		List<int> numeros = new List<int> { 5, 10, 15, 20, 25 };

		numeros.Add(30);

		numeros.Insert(0, 7);

		numeros.Remove(15);

		numeros.Sort();
		numeros.Reverse(); // Ordenar descendentment

		List<int> parells = numeros.Where(n => n % 2 == 0).ToList();

		// 🔹 Mostrar els resultats
		Console.WriteLine("Llista ordenada en ordre descendent:");
		Console.WriteLine(string.Join(", ", numeros));

		Console.WriteLine("\nNombres parells:");
	}

	/// <summary>
	/// Crea un programa que:
	///		Creï un Dictionary<string, int> per emmagatzemar noms d'estudiants i les seves edats.
	///		Afegeixi els següents valors:
	///		    "Marc" → 21
	///		    "Laura" → 19 
	///		    "Pau" → 22
	///		Mostri el diccionari per pantalla.
	///		Pregunti a l’usuari un nom i indiqui si existeix en el diccionari.
	///		Si el nom hi és, mostri la seva edat.
	///		Esborri "Laura" del diccionari.
	///		Iteri per totes les entrades i les mostri per pantalla.
	/// </summary>
	public static void Ex9()
    {
		Dictionary<string, int> estudiants = new Dictionary<string, int>
		{
			{ "Marc", 21 },
			{ "Laura", 19 },
			{ "Pau", 22 }
		};

		Console.WriteLine("📌 Diccionari inicial:");
		CollectionTools.PrintCollection(estudiants, "anys");

		Console.Write("\nIntrodueix un nom per buscar: ");
		string nom = Console.ReadLine();

		if (estudiants.TryGetValue(nom, out int edat))
		{
			Console.WriteLine($"· {nom} existeix al diccionari amb {edat} anys.");
		}
		else
		{
			Console.WriteLine($"X {nom} no es troba al diccionari.");
		}

		estudiants.Remove("Laura");
		Console.WriteLine("\n📌 Després d'eliminar 'Laura':");
		CollectionTools.PrintCollection(estudiants, "anys");
	}

}