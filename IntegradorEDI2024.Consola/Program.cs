using ConsoleTables;
using IntegradorEDI2024.Entidades;
using IntegradorEDI2024.Entidades.Dto;
using IntegradorEDI2024.Entidades.Enum;
using IntegradorEDI2024.Ioc;
using IntegradorEDI2024.Servicios.Interfaces;
using IntegradorEDI2024.Shared;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static IServiceProvider? serviceProvider;
    private static void Main(string[] args)
    {
        serviceProvider = DI.ConfigureServices();
        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Main Menú:");
            Console.WriteLine("1. Paginated list of brands");//ready
            Console.WriteLine("2. Add new brand");//ready
            Console.WriteLine("3. Delete brand");//ready
            Console.WriteLine("4. Edit brand");//ready
            Console.WriteLine("5. Paginated list order Z-A");
            Console.WriteLine("===============================");
            Console.WriteLine("10. Genres list");//ready
            Console.WriteLine("11. Add new Genre");//ready
            Console.WriteLine("12. Delete Genre");//ready
            Console.WriteLine("13. Edit Genre");//ready
            Console.WriteLine("14. Paginated list order Z-A");
            Console.WriteLine("===============================");
            Console.WriteLine("20. Colors list");//ready
            Console.WriteLine("21. Add new color");//ready
            Console.WriteLine("22. Delete color");//ready
            Console.WriteLine("23. Edit color");//ready
            Console.WriteLine("24. Paginated list order Z-A");
            Console.WriteLine("===============================");
            Console.WriteLine("30. Sports list");//ready
            Console.WriteLine("31. Add new Sport");//ready
            Console.WriteLine("32. Delete Sport");//ready
            Console.WriteLine("33. Edit Sport");//ready
            Console.WriteLine("34. Paginated list order Z-A");
            Console.WriteLine("===============================");
            Console.WriteLine("40. Shoes list");//ready
            Console.WriteLine("41. Add new Shoe");//ready
            Console.WriteLine("42. Delete Shoe");//ready
            Console.WriteLine("43. Edit Shoe");//ready
            Console.WriteLine("44. Paginated list shoes order by brand Z-A");
            Console.WriteLine("45. Paginated list shoes order by Sport A-Z");
            Console.WriteLine("46. Paginated list shoes order by Sport Z-A");
            Console.WriteLine("47. Paginated list shoes order by Genre A-Z");
            Console.WriteLine("48. Paginated list shoes order by Genre Z-A");
            Console.WriteLine("49. Paginated list shoes order by Color A-Z");
            Console.WriteLine("50. Paginated list shoes order by Color Z-A");
            Console.WriteLine("51. Paginated list shoes order by lowest price");
            Console.WriteLine("52. Paginated list shoes order by Highest price");
            Console.WriteLine("53. Paginated list shoes by brand");
            Console.WriteLine("54. Paginated list shoes by Sport");
            Console.WriteLine("55. Paginated list shoes by Genre");
            Console.WriteLine("56. Paginated list shoes by Color");//seguir con el listado

            Console.WriteLine("===============================");

            Console.WriteLine("x. Salir");

            Console.Write("Por favor, seleccione una opción: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Paginated list of brands");
                    brandsListPaginated(Orden.AZ);
                    ConsoleExtensions.Continue();
                    break;
                case "2":
                    Console.Clear();
                    AddBrand();
                    break;
                case "3":
                    Console.Clear();
                    DeleteBrand();
                    break;
                case "4":
                    Console.Clear();
                    EditBrand();
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("Paginated list of brands order Z-A");
                    brandsListPaginated(Orden.ZA);
                    break;
                case "10":
                    Console.Clear();
                    Console.WriteLine("Paginated list of genres");
                    GenreListPaginated(Orden.AZ);
                    ConsoleExtensions.Continue();
                    break;
                case "11":
                    Console.Clear();
                    AddGenre();
                    break;
                case "12":
                    Console.Clear();
                    DeleteGenre();
                    break;
                case "13":
                    Console.Clear();
                    EditGenre();
                    break;
                case "14":
                    Console.Clear();
                    Console.WriteLine("Paginated list of genres Order Z-A");
                    GenreListPaginated(Orden.ZA);
                    break;
                case "20":
                    Console.Clear();
                    Console.WriteLine("Paginated list of colors");
                    ColorListPaginated(Orden.AZ);
                    ConsoleExtensions.Continue();
                    break;
                case "21":
                    Console.Clear();
                    AddColor();
                    break;
                case "22":
                    Console.Clear();
                    DeleteColor();
                    break;
                case "23":
                    Console.Clear();
                    EditColor();
                    break;
                case "24":
                    Console.Clear();
                    Console.WriteLine("Paginated list of colors order Z-A");
                    ColorListPaginated(Orden.ZA);
                    break;
                case "30":
                    Console.Clear();
                    Console.WriteLine("Paginated list of sports");
                    SportListPaginated(Orden.AZ);
                    ConsoleExtensions.Continue();
                    break;
                case "31":
                    Console.Clear();
                    AddSport();
                    break;
                case "32":
                    Console.Clear();
                    DeleteSport();
                    break;
                case "33":
                    Console.Clear();
                    EditSport();
                    break;
                case "34":
                    Console.WriteLine("Paginated list of sports order Z-A");
                    Console.Clear();
                    SportListPaginated(Orden.ZA);
                    break;
                case "40":
                    Console.Clear();
                    ShoesListPaginated(Orden.AZ,null,null,null,null);
                    break;
                case "41":
                    Console.Clear();
                    AddShoes();
                    break;
                case "42":
                    Console.Clear();
                    DeleteShoes();
                    break;
                case "43":
                    Console.Clear();
                    EditShoes();
                    break;
                case "44":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by brand Z-A");
                    ShoesListPaginated(Orden.ZA, null, null, null, null);//
                    break;
                case "45":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by sport A-Z");
                    ShoesListPaginated(Orden.sportAZ, null, null, null, null);//
                    break;
                case "46":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by sport Z-A");
                    ShoesListPaginated(Orden.sportZA, null, null, null, null);//
                    break;
                case "47":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by genre A-Z");
                    ShoesListPaginated(Orden.genreAZ, null, null, null, null);//
                    break;
                case "48":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by genre Z-A");
                    ShoesListPaginated(Orden.genreZA, null, null, null, null);//
                    break;
                case "49":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by color A-Z");
                    ShoesListPaginated(Orden.colorAZ, null, null, null, null);//
                    break;
                case "50":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by color Z-A");
                    ShoesListPaginated(Orden.colorZA, null, null, null, null);//
                    break;
                case "51":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by lowestPrice");
                    ShoesListPaginated(Orden.LowestPrice, null, null, null, null);//
                    break;
                case "52":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes order by highest price");
                    ShoesListPaginated(Orden.highestPrice, null, null, null, null);//
                    break;
                case "53":
                    Console.Clear();
                    Console.WriteLine("Filter list by type");
                    SelectFilter();
                    break;
                case "54":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes by sport");
                    break;
                case "55":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes by Genre");
                    break;
                case "56":
                    Console.Clear();
                    Console.WriteLine("Paginated list shoes by color");
                    break;
                case "x":
                    exit = true;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }

            Console.WriteLine(); // Añade una línea en blanco para mejorar la legibilidad
            Console.Clear();
        }
    }

    private static void SelectFilter()
    {
        var BrandService = serviceProvider?.GetService<IBrandsService>();
        var SportService = serviceProvider?.GetService<ISportsService>();
        var GenreService = serviceProvider?.GetService<IGenreService>();
        var ColorService = serviceProvider?.GetService<IColorsService>();
        var ShoesService = serviceProvider?.GetService<IShoesService>();
        Brand? brand;
        Color? color;
        Genre? genre;
        Sport? sport;

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Filter menu:");
            Console.WriteLine("1. Filter by Brand");
            Console.WriteLine("2. Filter by Color");
            Console.WriteLine("3. Filter by Sport");
            Console.WriteLine("4. Filter by Genre");
            Console.WriteLine("4. Filter Mixed");
            Console.WriteLine("x. Exit");

            Console.Write("Por favor, seleccione una opción: ");
            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    brandsList(BrandService);
                    var optionsList = BrandService?.GetList().Select(b => b.BrandId.ToString()).ToList();
                    var brandId = ConsoleExtensions.GetOptions("Select a brand: ",optionsList);
                    brand= BrandService?.GetBrandById(Convert.ToInt32(brandId));
                    ShoesListPaginated(Orden.AZ, brand, null, null, null);
                    ConsoleExtensions.Continue();
                    break;
                case "2":
                    Console.Clear();
                    ColorList(ColorService);
                    optionsList = ColorService?.GetList().Select(x => x.ColorId.ToString()).ToList();
                    var colorId = ConsoleExtensions.GetOptions("Select a color: ", optionsList);
                    color = ColorService?.GetColorById(Convert.ToInt32(colorId));
                    ShoesListPaginated(Orden.AZ, null, color, null, null);
                    ConsoleExtensions.Continue();
                    break;
                case "3":
                    Console.Clear();
                    GenreList(GenreService);
                    optionsList = GenreService?.GetList().Select(x => x.GenreId.ToString()).ToList();
                    var genreId = ConsoleExtensions.GetOptions("Select a genre: ", optionsList);
                    genre = GenreService?.GetGenreById(Convert.ToInt32(genreId));
                    ShoesListPaginated(Orden.AZ, null, null, null, genre);
                    ConsoleExtensions.Continue();
                    break;
                case "4":
                    Console.Clear();
                    SportList(SportService);
                    optionsList = SportService?.GetList().Select(x => x.SportId.ToString()).ToList();
                    var sportId = ConsoleExtensions.GetOptions("Select a sport: ", optionsList);
                    sport = SportService?.GetSportById(Convert.ToInt32(sportId));
                    ShoesListPaginated(Orden.AZ, null, null, sport, null);
                    ConsoleExtensions.Continue();
                    break;
                
                case "x":
                    exit = true;
                    Console.WriteLine("Main menu");
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                    break;
            }
        }

    }

    private static void EditShoes()
    {
        Console.WriteLine("Editing Shoes");
        var BrandService = serviceProvider?.GetService<IBrandsService>();
        var SportService = serviceProvider?.GetService<ISportsService>();
        var GenreService = serviceProvider?.GetService<IGenreService>();
        var ColorService = serviceProvider?.GetService<IColorsService>();
        var ShoesService = serviceProvider?.GetService<IShoesService>();
        Brand? brand;
        Sport? sport;
        Color? color;
        Genre? genre;
        string description, model, brandId, sportId, colorId, genreId;
        bool go = true;
        do
        {
            ShoesList(ShoesService);
            int shoeId = ConsoleExtensions.GetInt("Indicate the id of the record to edit: ");
            var ShoeInDb = ShoesService?.GetShoeById(shoeId);
            if (ShoeInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you edit {ShoeInDb.name}? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Set new brand");
                        brandsList(BrandService);
                        var optionsList = BrandService?.GetList().Select(b => b.BrandId.ToString()).ToList();
                        brandId = ConsoleExtensions.GetOptions("Indicate the id of the record, or press [N] for a new brand: ", optionsList);
                        if (brandId == "N" || brandId == "n")
                        {
                            Console.Clear();
                            brandId = "0";
                            Console.WriteLine("Adding new brand");
                            var brandName = ConsoleExtensions.GetString("Insert brand name: ");
                            brand = new Brand()
                            {
                                BrandId = 0,
                                BrandName = brandName
                            };
                        }
                        else
                        {
                            brand = BrandService?.GetBrandById(Convert.ToInt32(brandId));
                        }
                        Console.Clear();
                        model = ConsoleExtensions.GetString("Insert new model: ");
                        Console.Clear();
                        Console.WriteLine("Set new color");
                        ColorList(ColorService);
                        optionsList = ColorService?.GetList().Select(c => c.ColorId.ToString()).ToList();
                        colorId = ConsoleExtensions.GetOptions("Indicate the id of the record, or press [N] for a new color: ", optionsList);
                        if (colorId == "N" || colorId == "n")
                        {
                            Console.Clear();
                            colorId = "0";
                            Console.WriteLine("Adding new color");
                            var colorName = ConsoleExtensions.GetString("Insert color name: ");
                            color = new Color()
                            {
                                ColorId = 0,
                                ColorName = colorName
                            };
                        }
                        else
                        {
                            color = ColorService?.GetColorById(Convert.ToInt32(colorId));
                        }
                        Console.Clear();
                        Console.WriteLine("Set new Sport");
                        SportList(SportService);
                        optionsList = SportService?.GetList().Select(s => s.SportId.ToString()).ToList();
                        sportId = ConsoleExtensions.GetOptions("Indicate the id of the record, or press [N] for a new sport: ", optionsList);
                        if (sportId == "N" || sportId == "n")
                        {
                            Console.Clear();
                            sportId = "0";
                            Console.WriteLine("Adding new sport");
                            var sportName = ConsoleExtensions.GetString("Insert sport name: ");
                            sport = new Sport()
                            {
                                SportId = 0,
                                SportName = sportName
                            };
                        }
                        else
                        {
                            sport = SportService?.GetSportById(Convert.ToInt32(sportId));
                        }
                        Console.Clear();
                        Console.WriteLine("Set new genre");
                        GenreList(GenreService);
                        optionsList = GenreService?.GetList().Select(c => c.GenreId.ToString()).ToList();
                        genreId = ConsoleExtensions.GetOptions("Indicate the id of the record, or press [N] for a new genre: ", optionsList);
                        if (genreId == "N" || genreId == "n")
                        {
                            Console.Clear();
                            genreId = "0";
                            Console.WriteLine("Adding new genre");
                            var genreName = ConsoleExtensions.GetString("Insert genre name: ");
                            genre = new Genre()
                            {
                                GenreId = 0,
                                GenreName = genreName
                            };
                        }
                        else
                        {
                            genre = GenreService?.GetGenreById(Convert.ToInt32(genreId));
                        }
                        Console.Clear();
                        description = ConsoleExtensions.GetString("Set new description: ");
                        Console.Clear();
                        decimal price = ConsoleExtensions.GetDecimal("Set new price: $", 1000);
                        ShoeInDb.Brand = brand;
                        ShoeInDb.BrandId = Convert.ToInt32(brandId);
                        ShoeInDb.Model = model;
                        ShoeInDb.Color = color;
                        ShoeInDb.ColorId = Convert.ToInt32(colorId);
                        ShoeInDb.Sport = sport;
                        ShoeInDb.SportId = Convert.ToInt32(sportId);
                        ShoeInDb.Genre = genre;
                        ShoeInDb.GenreId = Convert.ToInt32(genreId);
                        ShoeInDb.Description = description;
                        ShoeInDb.Price = price;
                        if (!ShoesService.Exist(ShoeInDb))
                        {
                            ShoesService.Save(ShoeInDb);
                            Console.WriteLine("Edited record!");
                            ConsoleExtensions.wait();
                        }
                        else
                        {
                            Console.WriteLine($"{ShoeInDb.name} already exist in the records");
                            ConsoleExtensions.wait();
                        }
                        go = false;
                        break;
                    case 2:
                        Console.WriteLine("Edit canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no record with the selected id, try again");
                Console.Clear();
            }
        } while (go);
    }

    private static void SportList(ISportsService? sportService)
    {
        Console.WriteLine("Sports list");
        var table = new ConsoleTable("ID", "Sport name");
        foreach (var sport in sportService.GetList())
        {
            table.AddRow(sport.SportId, sport.SportName);
        }
        table.Write();
        table.Options.EnableCount = false;
    }

    private static void ColorList(IColorsService? colorService)
    {
        Console.WriteLine("Colors list");
        var table = new ConsoleTable("ID", "Color name");
        foreach (var color in colorService.GetList())
        {
            table.AddRow(color.ColorId, color.ColorName);
        }
        table.Write();
        table.Options.EnableCount = false;
    }

    private static void GenreList(IGenreService? genreService)
    {
        Console.WriteLine("Genre list");
        var table = new ConsoleTable("ID", "Genre name");
        foreach (var genre in genreService.GetList())
        {
            table.AddRow(genre.GenreId, genre.GenreName);
        }
        table.Write();
        table.Options.EnableCount = false;
    }

    private static void ShoesList(IShoesService service)
    {
        Console.WriteLine("Shoes list");
        var table = new ConsoleTable("ID", "Brand", "Model", "Color", "Sport", "Genre", "Description", "Price");
        foreach (var shoe in service.GetList())
        {
            table.AddRow(shoe.ShoeId,
                         shoe.BrandName,
                         shoe.Model,
                         shoe.ColorName,
                         shoe.SportName,
                         shoe.GenreName,
                         shoe.Description,
                         shoe.Price.ToString("C"));
        }
        table.Write();
        table.Options.EnableCount = false;
    }

    private static void DeleteShoes()
    {
        Console.WriteLine("Deleting shoes");
        var service = serviceProvider?.GetService<IShoesService>();
        bool go = true;
        do
        {
            Console.Clear();
            ShoesList(service);
            int shoeId = ConsoleExtensions.GetInt("Indicate the id of the record to be deleted: ");
            var shoe = service?.GetShoeById(shoeId);
            if (shoe != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you delete {shoe.name} from the records? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        if (service != null)
                        {
                            service.Delete(shoe);
                            Console.Clear();
                            Console.WriteLine($"{shoe.name} has been successfully deleted!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Deletion canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no record with the selected id, try again");
                ConsoleExtensions.wait();
            }
        } while (go);
    }

    private static void AddShoes()
    {
        Console.WriteLine("Adding new shoes");
        var service = serviceProvider?.GetService<IShoesService>();
        var shoe = CreateNewShoe();
        if (service != null)
        {
            if (!service.Exist(shoe))
            {
                service.Save(shoe);
                Console.WriteLine($"{shoe.Brand.BrandName}-{shoe.Model} has been added successfully!");
                ConsoleExtensions.wait();
            }
            else
            {
                Console.WriteLine("The shoes already exist in the records");
                ConsoleExtensions.wait();
            }
        }
        else
        {
            Console.WriteLine("Sorry, we had a service error");
            ConsoleExtensions.wait();
        }
    }

    private static void EditSport()
    {
        Console.WriteLine("Editing sport");
        var service = serviceProvider?.GetService<ISportsService>();
        bool go = true;
        do
        {
            SportList(service);
            int sportId = ConsoleExtensions.GetInt("Indicate the id of the record to edit: ");
            var sportInDb = service?.GetSportById(sportId);
            if (sportInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you edit {sportInDb.SportName}? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        sportInDb.SportName = ConsoleExtensions.GetString("New name: ");
                        if (!service.Exist(sportInDb))
                        {
                            service.Save(sportInDb);
                            Console.WriteLine("Edited record!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine($"{sportInDb.SportName} already exist in the records");
                            ConsoleExtensions.wait();
                            go = false;
                            break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Edit canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no record with the selected id, try again");
                Console.Clear();
            }
        } while (go);
    }
    private static void DeleteSport()
    {
        Console.WriteLine("Deleting sport");
        var service = serviceProvider?.GetService<ISportsService>();
        bool go = true;
        do
        {
            Console.Clear();
            SportList(service);
            int sportId = ConsoleExtensions.GetInt("Indicate the id of the record to be deleted: ");
            var sport = service?.GetSportById(sportId);
            if (sport != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you delete {sport.SportName} from the records? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        if (!service.Related(sport))
                        {
                            service.Delete(sport);
                            Console.Clear();
                            Console.WriteLine($"{sport.SportName} has been successfully deleted!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine("Record is related, deletion denied");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Deletion canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no record with the selected id, try again");
                ConsoleExtensions.wait();

            }
        } while (go);
    }
    private static void AddSport()
    {
        Console.WriteLine("Adding new sport");
        var service = serviceProvider?.GetService<ISportsService>();
        var sport = new Sport();
        do
        {
            sport.SportName = ConsoleExtensions.GetString("Insert sport name: ");
            if (!service.Exist(sport))
            {
                service.Save(sport);
                Console.WriteLine($"{sport.SportName} has been saved successfully!");
                ConsoleExtensions.wait();
                break;
            }
            Console.WriteLine($"{sport.SportName} already exist in the records");
            ConsoleExtensions.wait();
            Console.Clear();
        } while (true);
    }
    private static void ShoesListPaginated(Orden orden,Brand? brand,Color? color,Sport? sport,Genre? genre)//mover despues de los metodos del CRUD de sport
    {
        Console.WriteLine("Paginated list of shoes");
        var service = serviceProvider?.GetService<IShoesService>();
        int records = service.GetQuantity(null,null,null,null);
        if (brand!=null)
        {
            records = service.GetQuantity(brand, null, null, null);
        }
        if (color != null)
        {
            records = service.GetQuantity(null,color, null, null);
        }
        if (sport != null)
        {
            records = service.GetQuantity(null, null, sport, null);
        }
        if (genre != null)
        {
            records = service.GetQuantity(null, null, null, genre);
        }
        int itemsPerPage = 10;
        int totalPages = ConsoleExtensions.calculatePages(records, itemsPerPage);
        for (int page = 0; page < totalPages; page++)
        {
            Console.WriteLine($"Page={page + 1}");
            List<ShoeListDto> paginatedList = service.GetPaginatedList(page, itemsPerPage, orden,null,null,null,null);
            if (brand != null)
            {
                paginatedList = service.GetPaginatedList(page, itemsPerPage, orden, brand, null, null, null);
            }
            if (color != null)
            {
                paginatedList = service.GetPaginatedList(page, itemsPerPage, orden, null, color, null, null);
            }
            if (sport != null)
            {
                paginatedList = service.GetPaginatedList(page, itemsPerPage, orden, null, null, sport, null);
            }
            if (genre != null)
            {
                paginatedList = service.GetPaginatedList(page, itemsPerPage, orden, null, null, null, genre);
            }
            var table = new ConsoleTable("ID", "Brand", "Model", "Color", "Sport", "Genre", "Description", "Price");
            foreach (var shoe in paginatedList)
            {
                table.AddRow(shoe.ShoeId,
                             shoe.BrandName,
                             shoe.Model,
                             shoe.ColorName,
                             shoe.SportName,
                             shoe.GenreName,
                             shoe.Description,
                             shoe.Price.ToString("C"));
            }
            table.Write();
            table.Options.EnableCount = false;
            ConsoleExtensions.Continue();
            Console.Clear();
        }
        Console.WriteLine("********THERE ARE NO MORE PAGES!!!**********");
        ConsoleExtensions.Continue();
    }

    private static void SportListPaginated(Orden orden)
    {

        var service = serviceProvider?.GetService<ISportsService>();
        int records = service.GetQuantity();
        int itemsPerPage = 10;
        int totalPages = ConsoleExtensions.calculatePages(records, itemsPerPage);
        for (int page = 0; page < totalPages; page++)
        {
            Console.WriteLine($"Page={page + 1}");
            List<Sport> paginatedList = service.GetPaginatedList(page, itemsPerPage, orden);
            var table = new ConsoleTable("ID", "Sport name");
            foreach (var sport in paginatedList)
            {
                table.AddRow(sport.SportId, sport.SportName);
            }
            table.Write();
            table.Options.EnableCount = false;
            ConsoleExtensions.Continue();
            Console.Clear();
        }
        Console.WriteLine("********THERE ARE NO MORE PAGES!!!**********");
    }

    private static void EditColor()
    {
        Console.WriteLine("Editing color");
        var service = serviceProvider?.GetService<IColorsService>();
        bool go = true;
        do
        {
            ColorList(service);
            int colorId = ConsoleExtensions.GetInt("Indicate the id of the record to edit: ");
            var colorInDb = service?.GetColorById(colorId);
            if (colorInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you edit {colorInDb.ColorName}? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        colorInDb.ColorName = ConsoleExtensions.GetString("New name: ");
                        if (!service.Exist(colorInDb))
                        {
                            service.Save(colorInDb);
                            Console.WriteLine("Edited record!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine($"{colorInDb.ColorName} already exist in the records");
                            ConsoleExtensions.wait();
                            go = false;
                            break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Edit canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no record with the selected id, try again");
                Console.Clear();
            }
        } while (go);
    }

    private static void DeleteColor()
    {
        Console.WriteLine("Deleting color");
        var service = serviceProvider?.GetService<IColorsService>();
        bool go = true;
        do
        {
            Console.Clear();
            ColorList(service);
            int colorId = ConsoleExtensions.GetInt("Indicate the id of the record to be deleted: ");
            var colorInDb = service?.GetColorById(colorId);
            if (colorInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you delete {colorInDb.ColorName} from the records? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        if (!service.Related(colorInDb))
                        {
                            service.Delete(colorInDb);
                            Console.Clear();
                            Console.WriteLine($"{colorInDb.ColorName} has been successfully deleted!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine("Record is related, deletion denied");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Deletion canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no record with the selected id, try again");
                ConsoleExtensions.wait();
            }
        } while (go);
    }

    private static void AddColor()
    {
        Console.WriteLine("Adding new color");
        var service = serviceProvider?.GetService<IColorsService>();
        var color = new Color();
        do
        {
            color.ColorName = ConsoleExtensions.GetString("Insert color name: ");
            if (!service.Exist(color))
            {
                service.Save(color);
                Console.WriteLine($"{color.ColorName} has been saved successfully!");
                ConsoleExtensions.wait();
                break;
            }
            Console.WriteLine($"{color.ColorName} already exist in the records");
            ConsoleExtensions.wait();
            Console.Clear();
        } while (true);
    }

    private static void ColorListPaginated(Orden orden)
    {
        Console.WriteLine("Paginated list of colors");
        var service = serviceProvider?.GetService<IColorsService>();
        int records = service.GetQuantity();
        int itemsPerPage = 10;
        int totalPages = ConsoleExtensions.calculatePages(records, itemsPerPage);
        for (int page = 0; page < totalPages; page++)
        {
            Console.WriteLine($"Page={page + 1}");
            List<Color> paginatedList = service.GetPaginatedList(page, itemsPerPage, orden);
            var table = new ConsoleTable("ID", "Color name");
            foreach (var color in paginatedList)
            {
                table.AddRow(color.ColorId, color.ColorName);
            }
            table.Write();
            table.Options.EnableCount = false;
            ConsoleExtensions.Continue();
            Console.Clear();
        }
        Console.WriteLine("********THERE ARE NO MORE PAGES!!!**********");
    }

    private static void EditGenre()
    {
        Console.WriteLine("Editing genre");
        var service = serviceProvider?.GetService<IGenreService>();
        bool go = true;
        do
        {
            GenreList(service);
            int genreId = ConsoleExtensions.GetInt("Indicate the id of the record to edit: ");
            var GenreInDb = service?.GetGenreById(genreId);
            if (GenreInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you edit {GenreInDb.GenreName}? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        GenreInDb.GenreName = ConsoleExtensions.GetString("New name: ");
                        if (!service.Exist(GenreInDb))
                        {
                            service.Save(GenreInDb);
                            Console.WriteLine("Edited record!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine($"{GenreInDb.GenreName} already exist in the records");
                            ConsoleExtensions.wait();
                            go = false;
                            break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Edit canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no record with the selected id, try again");
                Console.Clear();
            }
        } while (go);
    }

    private static void DeleteGenre()
    {
        Console.WriteLine("Deleting genre");
        var service = serviceProvider?.GetService<IGenreService>();
        bool go = true;
        do
        {
            Console.Clear();
            GenreList(service);
            int genreId = ConsoleExtensions.GetInt("Indicate the id of the record to be deleted: ");
            var GenreInDb = service?.GetGenreById(genreId);
            if (GenreInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you delete {GenreInDb.GenreName} from the records? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        if (!service.Related(GenreInDb))
                        {
                            service.Delete(GenreInDb);
                            Console.Clear();
                            Console.WriteLine($"{GenreInDb.GenreName} has been successfully deleted!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine("Record is related, deletion denied");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Deletion canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no record with the selected id, try again");
                ConsoleExtensions.wait();
            }
        } while (go);
    }

    private static void AddGenre()
    {
        Console.WriteLine("Adding new genre");
        var service = serviceProvider?.GetService<IGenreService>();
        var genre = new Genre();
        do
        {
            genre.GenreName = ConsoleExtensions.GetString("Insert new Genre name: ");
            if (!service.Exist(genre))
            {
                service.Save(genre);
                Console.WriteLine($"{genre.GenreName} has been saved successfully!");
                ConsoleExtensions.wait();
                break;
            }
            Console.WriteLine($"{genre.GenreName} already exist in the records");
            ConsoleExtensions.wait();
            Console.Clear();
        } while (true);
    }

    private static void GenreListPaginated(Orden orden)
    {
        var service = serviceProvider?.GetService<IGenreService>();
        int records = service.GetQuantity();
        int itemsPerPage = 10;
        int totalPages = ConsoleExtensions.calculatePages(records, itemsPerPage);
        for (int page = 0; page < totalPages; page++)
        {
            Console.WriteLine($"Page={page + 1}");
            List<Genre> paginatedList = service.GetPaginatedList(page, itemsPerPage, orden);
            var table = new ConsoleTable("ID", "Color name");
            foreach (var genre in paginatedList)
            {
                table.AddRow(genre.GenreId, genre.GenreName);
            }
            table.Write();
            table.Options.EnableCount = false;
            ConsoleExtensions.Continue();
            Console.Clear();
        }
        Console.WriteLine("********THERE ARE NO MORE PAGES!!!**********");
    }

    private static void EditBrand()
    {
        Console.WriteLine("Editing brand");
        var service = serviceProvider?.GetService<IBrandsService>();
        bool go = true;
        do
        {
            brandsList(service);
            int brandId = ConsoleExtensions.GetInt("Indicate the id of the record to edit: ");
            var brandInDb = service?.GetBrandById(brandId);
            if (brandInDb != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you edit {brandInDb.BrandName}? [1]Yes, [2]No,Cancel");
                switch (confirm)
                {
                    case 1:
                        brandInDb.BrandName = ConsoleExtensions.GetString("New name: ");
                        if (!service.Exist(brandInDb))
                        {
                            service.Save(brandInDb);
                            Console.WriteLine("Edited record!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine($"{brandInDb.BrandName} already exist in the records");
                            ConsoleExtensions.wait();
                            go = false;
                            break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("Edit canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("There is no record with the selected id, try again");
                Console.Clear();
            }
        } while (go);
    }

    private static void DeleteBrand()
    {
        Console.WriteLine("Deleting brand");
        var service = serviceProvider?.GetService<IBrandsService>();
        bool go = true;
        do
        {
            Console.Clear();
            brandsList(service);
            int brandId = ConsoleExtensions.GetInt("Indicate the id of the record to be deleted: ");
            var brand = service?.GetBrandById(brandId);
            if (brand != null)
            {
                int confirm = ConsoleExtensions.GetInt($"Are you sure you delete {brand.BrandName} from the records? [1]Yes, [2]No,Cancel: ");
                switch (confirm)
                {
                    case 1:
                        if (!service.Related(brand))
                        {
                            service.Delete(brand);
                            Console.Clear();
                            Console.WriteLine($"{brand.BrandName} has been successfully deleted!");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        else
                        {
                            Console.WriteLine("Record is related, deletion denied");
                            ConsoleExtensions.wait();
                            go = false;
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Deletion canceled");
                        ConsoleExtensions.wait();
                        go = false;
                        break;
                    default:
                        Console.WriteLine("Option no considered, try again");
                        ConsoleExtensions.wait();
                        break;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("There is no record with the selected id, try again");
                ConsoleExtensions.wait();

            }
        } while (go);
    }

    private static void brandsList(IBrandsService? service)
    {
        Console.WriteLine("Brand list");
        var table = new ConsoleTable("ID", "Brand name");
        foreach (var brand in service.GetList())
        {
            table.AddRow(brand.BrandId, brand.BrandName);
        }
        table.Write();
        table.Options.EnableCount = false;
    }

    private static void AddBrand()
    {
        Console.WriteLine("Adding new brand");
        var service = serviceProvider?.GetService<IBrandsService>();
        var brand = new Brand();
        do
        {
            brand.BrandName = ConsoleExtensions.GetString("Insert brand name: ");
            if (!service.Exist(brand))
            {
                service.Save(brand);
                Console.WriteLine($"{brand.BrandName} has been saved successfully!");
                ConsoleExtensions.wait();
                break;
            }
            Console.WriteLine($"{brand.BrandName} already exist in the records");
            ConsoleExtensions.wait();
            Console.Clear();
        } while (true);
    }
    private static void brandsListPaginated(Orden orden)
    {
        var service = serviceProvider?.GetService<IBrandsService>();
        int records = service.GetQuantity();
        int itemsPerPage = 10;
        int totalPages = ConsoleExtensions.calculatePages(records, itemsPerPage);
        for (int page = 0; page < totalPages; page++)
        {
            Console.WriteLine($"Page={page + 1}");
            var paginatedList = service.GetPaginatedList(page, itemsPerPage, orden);
            var table = new ConsoleTable("ID", "Brand name");
            foreach (var brand in paginatedList)
            {
                table.AddRow(brand.BrandId, brand.BrandName);
            }
            table.Write();
            table.Options.EnableCount = false;
            ConsoleExtensions.Continue();
            Console.Clear();
        }
        Console.WriteLine("********THERE ARE NO MORE PAGES!!!**********");
    }
    private static Shoe? CreateNewShoe()
    {
        var BrandsService = serviceProvider?.GetService<IBrandsService>();
        var SportService = serviceProvider?.GetService<ISportsService>();
        var GenresService = serviceProvider?.GetService<IGenreService>();
        var ColorsService = serviceProvider?.GetService<IColorsService>();
        Shoe? Shoe;
        Brand? brand;
        Sport? sport;
        Genre? genre;
        Color? color;
        string model;
        string description;
        decimal price;
        string sportId, brandId, colorId, genreId;

        brandsList(BrandsService);
        var optionsList = BrandsService?.GetList().Select(b => b.BrandId.ToString()).ToList();
        brandId = ConsoleExtensions.GetOptions("Select the ID of a brand or press [N] to add a new brand : ", optionsList);
        if (brandId == "N" || brandId == "n")//bloque para agregado de brand
        {
            Console.Clear();
            brandId = "0";
            Console.WriteLine("Adding new brand");
            var brandName = ConsoleExtensions.GetString("Insert brand name: ");
            brand = new Brand()
            {
                BrandId = 0,
                BrandName = brandName,
            };
        }
        else
        {
            brand = BrandsService?.GetBrandById(Convert.ToInt32(brandId));
        }

        Console.Clear();
        model = ConsoleExtensions.GetString("Enter the model of the shoes: ");
        Console.Clear();
        ColorList(ColorsService);
        optionsList = ColorsService?.GetList().Select(c => c.ColorId.ToString()).ToList();
        colorId = ConsoleExtensions.GetOptions("Select the ID of a color or press [N] to add a new color : ", optionsList);
        if (colorId == "N" || colorId == "n")//bloque para agregado de color
        {
            Console.Clear();
            colorId = "0";
            Console.WriteLine("Adding new color");
            var colorName = ConsoleExtensions.GetString("Insert color name: ");
            color = new Color()
            {
                ColorId = 0,
                ColorName = colorName
            };
        }
        else
        {
            color = ColorsService?.GetColorById(Convert.ToInt32(colorId));
        }
        Console.Clear();
        SportList(SportService);
        optionsList = SportService?.GetList().Select(s => s.SportId.ToString()).ToList();
        sportId = ConsoleExtensions.GetOptions("Select the ID of a sport or press [N] to add a new sport : ", optionsList);
        if (sportId == "N" || sportId == "n")//bloque para agregado de Sport
        {
            Console.Clear();
            sportId = "0";
            Console.WriteLine("Adding new sport");
            var sportName = ConsoleExtensions.GetString("Insert sport name: ");
            sport = new Sport()
            {
                SportId = 0,
                SportName = sportName,
            };
        }
        else
        {
            sport = SportService?.GetSportById(Convert.ToInt32(sportId));
        }
        Console.Clear();
        GenreList(GenresService);
        optionsList = GenresService?.GetList().Select(g => g.GenreId.ToString()).ToList();
        genreId = ConsoleExtensions.GetOptions("Select the ID of a genre or press [N] to add a new genre : ", optionsList);
        if (genreId == "N" || genreId=="n")//bloque para agregado de genres
        {
            Console.Clear();
            genreId = "0";
            Console.WriteLine("Adding new genre");
            var genreName = ConsoleExtensions.GetString("Insert genre name: ");
            genre = new Genre()
            {
                GenreId = 0,
                GenreName = genreName
            };
        }
        else
        {
            genre = GenresService?.GetGenreById(Convert.ToInt32(genreId));
        }
        Console.Clear();
        description = ConsoleExtensions.GetString("Enter the description: ");
        Console.Clear();
        price = ConsoleExtensions.GetDecimal("Enter the price: ", 1000);
        Shoe = new Shoe()
        {
            Brand = brand,
            BrandId = Convert.ToInt32(brandId),
            Sport = sport,
            SportId = Convert.ToInt32(sportId),
            Color = color,
            ColorId = Convert.ToInt32(colorId),
            Genre = genre,
            GenreId = Convert.ToInt32(genreId),
            Model = model,
            Description = description,
            Price = price
        };
        return Shoe;
    }
}