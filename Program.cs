//variaveis declaradas em camelCase
string mensagemBoasVindas = "Seja bem vindo ao ScreenSound";

List<string> listaDasBandas = new List<string> { "U2", "Beatles", "Calipso"}; //criando lista de strings 

//palavra reservada void para indicar funcao. Funcoes escritas em PascalCase
void ExibirLogoProjeto()
{
    //Verbatim literal: uso de @ para mostrar a string como ela será apresentada no console, facilitando visualizacao
    Console.WriteLine(@"
        
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");
    Console.WriteLine(mensagemBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogoProjeto();
    Console.WriteLine("\nDigite 1 para registrar uma banda.");
    Console.WriteLine("Digite 2 para mostrar todas as bandas.");
    Console.WriteLine("Digite 3 para avaliar uma banda.");
    Console.WriteLine("Digite 4 para exibir a média de avaliacao de uma banda.");
    Console.WriteLine("Digite -1 para sair.");

    Console.Write("\nDigite a sua opcao: ");
    string opcaoEscolhida = Console.ReadLine()!; //nesse caso o ! impede que a string seja null
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida); //convertendo string para int para fazer comparação a seguir
    
    switch(opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: Console.WriteLine("Você escolheu a opcao " + opcaoEscolhidaNumerica);
            break;
        case 4: Console.WriteLine("Você escolheu a opcao " + opcaoEscolhidaNumerica);
            break;
        case -1: Console.WriteLine("Tchau :)");
            break;
        default: Console.WriteLine("Comando inválido.");
            break;
    }
}

ExibirOpcoesDoMenu();

void RegistrarBanda()
{
    Console.Clear();
    Console.WriteLine("Registro de Bandas\n");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    listaDasBandas.Add(nomeDaBanda); //inserindo a banda na lista
    Console.WriteLine($"Você registrou a banda {nomeDaBanda} com sucesso!");
    Thread.Sleep(2000); //tempo de espera em milissegundos p retornar ao menu
    Console.Clear();
    ExibirOpcoesDoMenu(); //retornando ao menu

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    Console.WriteLine("Mostrar bandas registradas\n");

    //for (int i = 0; i < listaDasBandas.Count; i++) //percorrendo itens da lista
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    //outra opcao:
    foreach (string banda in listaDasBandas)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite qualquer tecla para retornar ao menu principal.");
    Console.ReadKey(); //lendo qualquer tecla
    Console.Clear();
    ExibirOpcoesDoMenu();
}
