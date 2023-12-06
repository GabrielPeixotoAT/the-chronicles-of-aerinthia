using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager
{
    public static DialogsBase DialogsBase { get; set; }

    private static int lastChoose;

    public static void LoadDialogs()
    {
        try
        {
            if (!System.IO.File.Exists(GameInfo.DialogDataPath))
                CreateFile();

            string dialogsJson = System.IO.File.ReadAllText(GameInfo.DialogDataPath);

            DialogsBase = JsonUtility.FromJson<DialogsBase>(dialogsJson);

            Debug.Log("Dialogs loaded successfully!");
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }
    
    public static Dialog NextDialog()
    {
        int choose = 0;

        do
        {
            choose = UnityEngine.Random.Range(0, DialogsBase.DialogsList.Count);
        } while (choose == lastChoose);

        var dialogData = DialogsBase.DialogsList[choose];

        DialogsBase.DialogsList.Remove(DialogsBase.DialogsList[choose]);

        var dialog = new Dialog
        {
            Title = dialogData.Title,
            Message = dialogData.Message,
            IsQuestion = dialogData.IsQuestion,
            Answer = dialogData.Answer,
        };

        return dialog;
    }

    public static void CreateFile()
    {
        string dialogsJson = "{\r\n    \"DialogsList\":[\r\n        {\r\n            \"Title\": \"Comerciante\",\r\n            \"Message\": \"Com 400 das moedas que você tem, você compraria 2 cavalos nos estábulos. O preço dos suprimeiros que você precisa é de um décimo do preço de cada cavalo.\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"20\"\r\n        },\r\n        {\r\n            \"Title\": \"Comerciante\",\r\n            \"Message\": \"O último comprador pagou 32 moedas, e pegou 2 vezes mais suprimentos que você.\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"16\"\r\n        },\r\n        {\r\n            \"Title\": \"Vendedor\",\r\n            \"Message\": \"Um vinho que acabou de ser fabricado custa 20 moedas, um vinho envelhecido por 10 anos custa 100,  supondo que o valor do vinho suba com o tempo de forma constante, quanto custaria um vinho envelhecido por 7 anos?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"76\"\r\n        },\r\n        {\r\n            \"Title\": \"O vendedor diz a Léo\",\r\n            \"Message\": \"Um entregador vai vir entregar as mercadorias hoje, mas não sei quanto vou ter que pagar pela entrega. O valor são 26 moedas iniciais mais 17 moedas por léguas percorridas. A viajem dura 4 léguas no total. Qual será o valor que terei que pagar no fim ao entregador?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"94\"\r\n        },\r\n        {\r\n            \"Title\": \"O padeiro diz a Léo\",\r\n            \"Message\": \"Sobraram pães e bolos de ontem. Ninguém vai querer comprá-los hoje... Mas eu tive uma ideia, irei dar um desconto! Cada pão custa 3 moedas, e cada bolo custa 6. Ainda há doze pães e quatro bolos a serem vendidos. Para o bolo, irei vendê-lo pela metade do preço, e os pães por um terço. Qual será o valor que irei arrecadar dos pães e bolos com desconto?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"24\"\r\n        },\r\n        {\r\n            \"Title\": \"Um fazendeiro pede ajuda a Léo\",\r\n            \"Message\": \"Nas minhas terras eu produzo trigo e farinha. Nos últimos meses entramos em uma seca das grandes que fez com que o trigo e seus derivados subissem o preço consideravelmente. O preço que eu costumava vender o saco de trigo era de 7 moedas, e o de farinha, 11. O preço hoje é o dobro disso. Eu tenho 14 sacos de trigo e 5 de farinha para vender. Quantas moedas eu irei receber caso venda meus produtos hoje?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"306\"\r\n        },\r\n        {\r\n            \"Title\": \"Comerciante\",\r\n            \"Message\": \"O líder do vilarejo encomendou 10 espadas de ferro. Para fazê-las sem desperdiçar material eu preciso calcular quanto eu devo comprar. Para cada espada eu utilizo de uma liga metálica e para fazer essa liga eu utilizo 2 peças de ferro e 1 de carvão. Cada peça de ferro custa 6 moedas e cada peça de carvão, 2 moedas. Quantas moedas eu irei gastar de material para fazer essas espadas?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"140\"\r\n        }   \r\n    ]\r\n}";

        var dialogsBase = JsonUtility.FromJson<DialogsBase>(dialogsJson);

        string dialogsJson2 = JsonUtility.ToJson(dialogsBase);

        System.IO.File.WriteAllText(GameInfo.DialogDataPath, dialogsJson2);
    }
}
[Serializable]
public class DialogsBase
{
    public List<DialogData> DialogsList;
}

[Serializable]
public class DialogData
{
    public string Title;
    [TextArea(2, 6)]
    public string Message;
    public bool IsQuestion;
    public string Answer;
}
