using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Shared.Entities;

class Program
{
    static readonly HttpClient client = new HttpClient();

    static async Task Main(string[] args)
    {
        client.BaseAddress = new Uri("https://localhost:7005/api/");
        bool salirPrograma = false;

        while (!salirPrograma)
        {
            Console.WriteLine("=== Seleccionar con que entidad trabajar ===");
            Console.WriteLine("1. Animales");
            Console.WriteLine("2. Duenios");
            Console.WriteLine("3. Atenciones");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            var opcionpadre = Console.ReadLine();

            switch (opcionpadre)
            {
                case "1":
                    await MenuAnimales();
                    break;
                case "2":
                    await MenuDuenios();
                    break;
                case "3":
                    await MenuAtenciones();
                    break;
                case "4":
                    salirPrograma = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    static async Task MenuAnimales()
    {
        bool salirAnimales = false;
        while (!salirAnimales)
        {
            Console.WriteLine("=== Menú de Animales ===");
            Console.WriteLine("1. Listar animales");
            Console.WriteLine("2. Ver animal por ID");
            Console.WriteLine("3. Agregar animal");
            Console.WriteLine("4. Eliminar animal");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await ListarAnimales();
                    break;
                case "2":
                    await VerAnimalPorId();
                    break;
                case "3":
                    await AgregarAnimal();
                    break;
                case "4":
                    await AliminarAnimal();
                    break;
                case "5":
                    await ModificarAnimal();
                    break;
                case "6":
                    salirAnimales = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static async Task MenuDuenios()
    {
        bool salirDuenios = false;
        while (!salirDuenios)
        {
            Console.WriteLine("=== Menú de Dueños ===");
            Console.WriteLine("1. Listar dueños");
            Console.WriteLine("2. Ver dueño por ID");
            Console.WriteLine("3. Agregar dueño");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await ListarDuenios();
                    break;
                case "2":
                    await VerDuenioPorId();
                    break;
                case "3":
                    await AgregarDuenio();
                    break;
                case "4":
                    await EliminarDuenio();
                    break;
                case "5":
                    await ModificarDuenio();
                    break;
                case "6":
                    salirDuenios = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    static async Task MenuAtenciones()
    {
        bool salirAtenciones = false;
        while (!salirAtenciones)
        {
            Console.WriteLine("=== Menú de Atenciones ===");
            Console.WriteLine("1. Listar atenciones");
            Console.WriteLine("2. Ver atención por ID");
            Console.WriteLine("3. Agregar atención");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await ListarAtenciones();
                    break;
                case "2":
                    await VerAtencionPorId();
                    break;
                case "3":
                    await AgregarAtencion();
                    break;
                case "4":
                    await EliminarAtencion();
                    break;
                case "5":
                    await ModificarAtencion();
                    break;
                case "6":
                    salirAtenciones = true;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    // Métodos para interactuar con la API de Animales

    static async Task ListarAnimales()
    {
        var animales = await client.GetFromJsonAsync<List<AnimalsDTO>>("animals");
        foreach (var animal in animales)
        {
            Console.WriteLine($"ID: {animal.Id}, Nombre: {animal.Name}, Raza: {animal.Race}, Fecha de nacimiento: {animal.birthdate}, Sexo: {animal.Sex}, DNI duenio: {animal.OwnerDni}");
        }
    }

    static async Task VerAnimalPorId()
    {
        Console.Write("Ingrese el ID del animal: ");
        var id = Console.ReadLine();
        var animal = await client.GetFromJsonAsync<AnimalsDTO>($"animals/{id}");
        Console.WriteLine($"ID: {animal.Id}, Nombre: {animal.Name}, Raza: {animal.Race}");
    }

    static async Task AgregarAnimal()
    {
        var nuevoAnimal = new AnimalsDTO();
        Console.Write("Nombre: ");
        nuevoAnimal.Name = Console.ReadLine();
        Console.Write("Raza: ");
        nuevoAnimal.Race = Console.ReadLine();
        Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
        nuevoAnimal.birthdate = DateTime.Parse(Console.ReadLine());
        Console.Write("Sexo (M/F): ");
        nuevoAnimal.Sex = Console.ReadLine();
        Console.Write("DNI del dueño: ");
        nuevoAnimal.OwnerDni = Console.ReadLine();

        var response = await client.PostAsJsonAsync("animals", nuevoAnimal);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Animal agregado con éxito.");
        }
        else
        {
            Console.WriteLine("Error al agregar animal.");
        }
    }

    static async Task AliminarAnimal()
    {
        Console.Write("Ingrese el ID del animal a eliminar: ");
        var id = Console.ReadLine();
        var response = await client.DeleteAsync($"animals/{id}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Animal eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Error al eliminar animal.");
        }
    }

    static async Task ModificarAnimal()
    {
        Console.Write("Ingrese el ID del animal a modificar: ");
        var id = Console.ReadLine();
        var nuevoAnimal = new AnimalsDTO();
        Console.Write("Nombre: ");
        nuevoAnimal.Name = Console.ReadLine();
        Console.Write("Raza: ");
        nuevoAnimal.Race = Console.ReadLine();
        Console.Write("Fecha de nacimiento (yyyy-MM-dd): ");
        nuevoAnimal.birthdate = DateTime.Parse(Console.ReadLine());
        Console.Write("Sexo (M/F): ");
        nuevoAnimal.Sex = Console.ReadLine();
        Console.Write("DNI del dueño: ");
        nuevoAnimal.OwnerDni = Console.ReadLine();
        var response = await client.PutAsJsonAsync($"animals/{id}", nuevoAnimal);

    }

    // Métodos para interactuar con la API de duenios

    static async Task ListarDuenios()
    {
        var duenios = await client.GetFromJsonAsync<List<OwnersDTO>>("owners");
        foreach (var duenio in duenios)
        {
            Console.WriteLine($"ID: {duenio.Id}, Nombre: {duenio.Name}, Apellido: {duenio.Surname}, DNI: {duenio.Dni}");
        }
    }

    static async Task VerDuenioPorId()
    {
        Console.Write("Ingrese el ID del dueño: ");
        var id = Console.ReadLine();
        var duenio = await client.GetFromJsonAsync<OwnersDTO>($"owners/{id}");
        Console.WriteLine($"ID: {duenio.Id}, Nombre: {duenio.Name}, Apellido: {duenio.Surname}, DNI: {duenio.Dni}");
    }

    static async Task AgregarDuenio()
    {
        var duenio = new OwnersDTO();
        Console.Write("DNI: ");
        duenio.Dni = Console.ReadLine();
        Console.Write("Nombre: ");
        duenio.Name = Console.ReadLine();
        Console.Write("Apellido: ");
        duenio.Surname = Console.ReadLine();


        var response = await client.PostAsJsonAsync("owners", duenio);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Dueño agregado con éxito.");
        }
        else
        {
            Console.WriteLine("Error al agregar dueño.");
        }
    }

    static async Task EliminarDuenio()
    {
        Console.Write("Ingrese el ID del dueño a eliminar: ");
        var id = Console.ReadLine();
        var response = await client.DeleteAsync($"owners/{id}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Dueño eliminado con éxito.");
        }
        else
        {
            Console.WriteLine("Error al eliminar dueño.");
        }
    }

    static async Task ModificarDuenio()
    {
        Console.Write("Ingrese el ID del dueño a modificar: ");
        var id = Console.ReadLine();
        var duenio = new OwnersDTO();
        Console.Write("DNI: ");
        duenio.Dni = Console.ReadLine();
        Console.Write("Nombre: ");
        duenio.Name = Console.ReadLine();
        Console.Write("Apellido: ");
        duenio.Surname = Console.ReadLine();
        var response = await client.PutAsJsonAsync($"owners/{id}", duenio);
    }

    // Métodos para interactuar con la API de Attentions

    static async Task ListarAtenciones()
    {
        var atenciones = await client.GetFromJsonAsync<List<AttentionsDTO>>("attentions");
        foreach (var atencion in atenciones)
        {
            Console.WriteLine($"ID: {atencion.Id}, AnimalId: {atencion.AnimalId}, Razon de consulta: {atencion.ReasonForConsultation}, Tratamiento: {atencion.Treatment}, Medicamento{atencion.Medications}, Fecha: {atencion.Date}");
        }
    }
    static async Task VerAtencionPorId()
    {
        Console.Write("Ingrese el ID de la atención: ");
        var id = Console.ReadLine();
        var atencion = await client.GetFromJsonAsync<AttentionsDTO>($"attentions/{id}");
        Console.WriteLine($"ID: {atencion.Id}, AnimalId: {atencion.AnimalId}, Razon de consulta: {atencion.ReasonForConsultation}, Tratamiento: {atencion.Treatment}, Medicamento{atencion.Medications}, Fecha: {atencion.Date}");
    }

    static async Task AgregarAtencion()
    {
        var atencion = new AttentionsDTO();

        Console.Write("ID del animal: ");
        atencion.AnimalId = int.Parse(Console.ReadLine());
        Console.Write("Razon de consulta: ");
        atencion.ReasonForConsultation = Console.ReadLine();
        Console.Write("Tratamiento: ");
        atencion.Treatment = Console.ReadLine();
        Console.Write("Medicacion: ");
        atencion.Medications = Console.ReadLine();
        Console.Write("Fecha (yyyy-MM-dd): ");
        atencion.Date = DateTime.Parse(Console.ReadLine());


        var response = await client.PostAsJsonAsync("attentions", atencion);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Atención agregada con éxito.");
        }
        else
        {
            Console.WriteLine("Error al agregar atención.");
        }
    }
    static async Task EliminarAtencion()
    {
        Console.Write("Ingrese el ID de la atención a eliminar: ");
        var id = Console.ReadLine();
        var response = await client.DeleteAsync($"attentions/{id}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Atención eliminada con éxito.");
        }
        else
        {
            Console.WriteLine("Error al eliminar atención.");
        }
    }
    static async Task ModificarAtencion()
    {
        Console.Write("Ingrese el ID de la atención a modificar: ");
        var id = Console.ReadLine();
        var atencion = new AttentionsDTO();
        Console.Write("ID del animal: ");
        atencion.AnimalId = int.Parse(Console.ReadLine());
        Console.Write("Razon de consulta: ");
        atencion.ReasonForConsultation = Console.ReadLine();
        Console.Write("Tratamiento: ");
        atencion.Treatment = Console.ReadLine();
        Console.Write("Medicacion: ");
        atencion.Medications = Console.ReadLine();
        Console.Write("Fecha (yyyy-MM-dd): ");
        atencion.Date = DateTime.Parse(Console.ReadLine());
        var response = await client.PutAsJsonAsync($"attentions/{id}", atencion);
    }
}

