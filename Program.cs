//variaveis declaradas em camelCase
string mensagemBoasVindas = "Seja bem vindo ao ScreenSound";

//List<string> listaDasBandas = new List<string> { "U2", "Beatles", "Calipso"}; //criando lista de strings 
//Para poder cadastrar as notas das bandas, sem definir a quantidade de avaliacoes que cada banda vai receber, é preciso usar o dicionario e refatorar o codigo
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>(); //criando um dicionario vazio
bandasRegistradas.Add("u2", new List<int> { 10, 8, 6}); //inserindo banda para teste no dicionario
bandasRegistradas.Add("Beatles", new List<int>());

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
        case 2: 
            MostrarBandasRegistradas();
            break;
        case 3: 
            AvaliarBanda();
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
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>()); //adicionando banda ao dicionario e lista vazia de notas
    Console.WriteLine($"Você registrou a banda {nomeDaBanda} com sucesso!");
    Thread.Sleep(2000); //tempo de espera em milissegundos p retornar ao menu
    Console.Clear();
    ExibirOpcoesDoMenu(); //retornando ao menu

}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Mostrar Bandas Registradas");

    //for (int i = 0; i < listaDasBandas.Count; i++) //percorrendo itens da lista
    //{
    //    Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    //outra opcao:
    foreach (string banda in bandasRegistradas.Keys) //para cada elemento chave(banda) do dicionario
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite qualquer tecla para retornar ao menu principal.");
    Console.ReadKey(); //lendo qualquer tecla
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void AvaliarBanda()
{
    //digitar a banda que deseja avaliar,
    //verificar se a banda está cadastrada no dicionario, atribuir nota para a banda
    //se nao estiver cadastrada, exibir uma mensagem

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar Banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Que nota a banda {nomeDaBanda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota); //atribuindo nota para a banda existente no dicionario
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}.");
        Thread.Sleep(2000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    } else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite uma tecla para sair");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirTituloDaOpcao (string tituloDaOpcao)
{
    int caracteresTituloDaOpcao = tituloDaOpcao.Length;
    string asteriscos = string.Empty.PadLeft(caracteresTituloDaOpcao, '*'); //asteriscos recebeu uma string vazia com a funcao PadLeft que adiciona caracteres a esquerda com a estrutura (quantidade de vezes, 'caractere')
    Console.WriteLine(asteriscos);
    Console.WriteLine(tituloDaOpcao);
    Console.WriteLine(asteriscos + "\n");
}