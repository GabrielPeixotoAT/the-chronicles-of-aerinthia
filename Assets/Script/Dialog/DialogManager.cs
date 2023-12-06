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
        string dialogsJson = "{\r\n    \"DialogsList\":[\r\n        {\r\n            \"Title\": \"Comerciante\",\r\n            \"Message\": \"Com 400 das moedas que voc� tem, voc� compraria 2 cavalos nos est�bulos. O pre�o dos suprimeiros que voc� precisa � de um d�cimo do pre�o de cada cavalo.\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"20\"\r\n        },\r\n        {\r\n            \"Title\": \"Comerciante\",\r\n            \"Message\": \"O �ltimo comprador pagou 32 moedas, e pegou 2 vezes mais suprimentos que voc�.\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"16\"\r\n        },\r\n        {\r\n            \"Title\": \"Vendedor\",\r\n            \"Message\": \"Um vinho que acabou de ser fabricado custa 20 moedas, um vinho envelhecido por 10 anos custa 100,  supondo que o valor do vinho suba com o tempo de forma constante, quanto custaria um vinho envelhecido por 7 anos?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"76\"\r\n        },\r\n        {\r\n            \"Title\": \"O vendedor diz a L�o\",\r\n            \"Message\": \"Um entregador vai vir entregar as mercadorias hoje, mas n�o sei quanto vou ter que pagar pela entrega. O valor s�o 26 moedas iniciais mais 17 moedas por l�guas percorridas. A viajem dura 4 l�guas no total. Qual ser� o valor que terei que pagar no fim ao entregador?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"94\"\r\n        },\r\n        {\r\n            \"Title\": \"O padeiro diz a L�o\",\r\n            \"Message\": \"Sobraram p�es e bolos de ontem. Ningu�m vai querer compr�-los hoje... Mas eu tive uma ideia, irei dar um desconto! Cada p�o custa 3 moedas, e cada bolo custa 6. Ainda h� doze p�es e quatro bolos a serem vendidos. Para o bolo, irei vend�-lo pela metade do pre�o, e os p�es por um ter�o. Qual ser� o valor que irei arrecadar dos p�es e bolos com desconto?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"24\"\r\n        },\r\n        {\r\n            \"Title\": \"Um fazendeiro pede ajuda a L�o\",\r\n            \"Message\": \"Nas minhas terras eu produzo trigo e farinha. Nos �ltimos meses entramos em uma seca das grandes que fez com que o trigo e seus derivados subissem o pre�o consideravelmente. O pre�o que eu costumava vender o saco de trigo era de 7 moedas, e o de farinha, 11. O pre�o hoje � o dobro disso. Eu tenho 14 sacos de trigo e 5 de farinha para vender. Quantas moedas eu irei receber caso venda meus produtos hoje?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"306\"\r\n        },\r\n        {\r\n            \"Title\": \"Comerciante\",\r\n            \"Message\": \"O l�der do vilarejo encomendou 10 espadas de ferro. Para faz�-las sem desperdi�ar material eu preciso calcular quanto eu devo comprar. Para cada espada eu utilizo de uma liga met�lica e para fazer essa liga eu utilizo 2 pe�as de ferro e 1 de carv�o. Cada pe�a de ferro custa 6 moedas e cada pe�a de carv�o, 2 moedas. Quantas moedas eu irei gastar de material para fazer essas espadas?\",\r\n            \"IsQuestion\": true,\r\n            \"Answer\": \"140\"\r\n        }   \r\n    ]\r\n}";

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
