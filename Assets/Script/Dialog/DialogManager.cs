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
    
    public static DialogData NextDialog()
    {
        int choose = 0;

        do
        {
            choose = UnityEngine.Random.Range(0, DialogsBase.DialogsList.Count);
        } while (choose == lastChoose);

        var dialogData = DialogsBase.DialogsList[choose];

        DialogsBase.DialogsList.Remove(DialogsBase.DialogsList[choose]);

        return dialogData;
    }

    public static void CreateFile()
    {
        string dialogsJson = "{\"DialogsList\":[{\"Title\":\"Comerciante\",\"Message\":\"Com 400 das moedas que voc� tem, voc� compraria 2 cavalos nos est�bulos. O pre�o dos suprimeiros que voc� precisa � de um d�cimo do pre�o de cada cavalo.\",\"IsQuestion\":true,\"Answer\":\"20\"},{\"Title\":\"Comerciante\",\"Message\":\"O �ltimo comprador pagou 32 moedas, e pegou 2 vezes mais suprimentos que voc�.\",\"IsQuestion\":true,\"Answer\":\"16\"},{\"Title\":\"Vendedor\",\"Message\":\"Um vinho que acabou de ser fabricado custa 20 moedas, um vinho envelhecido por 10 anos custa 100,  supondo que o valor do vinho suba com o tempo de forma constante, quanto custaria um vinho envelhecido por 7 anos?\",\"IsQuestion\":true,\"Answer\":\"76\"},{\"Title\":\"O vendedor diz a L�o\",\"Message\":\"Um entregador vai vir entregar as mercadorias hoje, mas n�o sei quanto vou ter que pagar pela entrega. O valor s�o 26 moedas iniciais mais 17 moedas por l�guas percorridas. A viajem dura 4 l�guas no total. Qual ser� o valor que terei que pagar no fim ao entregador?\",\"IsQuestion\":true,\"Answer\":\"94\"},{\"Title\":\"O padeiro diz a L�o\",\"Message\":\"Sobraram p�es e bolos de ontem. Ningu�m vai querer compr�-los hoje... Mas eu tive uma ideia, irei dar um desconto! Cada p�o custa 3 moedas, e cada bolo custa 6. Ainda h� doze p�es e quatro bolos a serem vendidos. Para o bolo, irei vend�-lo pela metade do pre�o, e os p�es por um ter�o. Qual ser� o valor que irei arrecadar dos p�es e bolos com desconto?\",\"IsQuestion\":true,\"Answer\":\"24\"},{\"Title\":\"Um fazendeiro pede ajuda a L�o\",\"Message\":\"Nas minhas terras eu produzo trigo e farinha. Nos �ltimos meses entramos em uma seca das grandes que fez com que o trigo e seus derivados subissem o pre�o consideravelmente. O pre�o que eu costumava vender o saco de trigo era de 7 moedas, e o de farinha, 11. O pre�o hoje � o dobro disso. Eu tenho 14 sacos de trigo e 5 de farinha para vender. Quantas moedas eu irei receber caso venda meus produtos hoje?\",\"IsQuestion\":true,\"Answer\":\"306\"},{\"Title\":\"Comerciante\",\"Message\":\"O l�der do vilarejo encomendou 10 espadas de ferro. Para faz�-las sem desperdi�ar material eu preciso calcular quanto eu devo comprar. Para cada espada eu utilizo de uma liga met�lica e para fazer essa liga eu utilizo 2 pe�as de ferro e 1 de carv�o. Cada pe�a de ferro custa 6 moedas e cada pe�a de carv�o, 2 moedas. Quantas moedas eu irei gastar de material para fazer essas espadas?\",\"IsQuestion\":true,\"Answer\":\"140\"},{\"Title\":\"D�vida de L�o\",\"Message\":\"Dessa vez L�o gastou 18 de suas moedas para pagar as refei��es e uma di�ria em uma pousada, o que representa um aumento de 20% do que ele gastava anteriormente. Quantas moedas L�o pagava antes desse aumento de gastos?\",\"IsQuestion\":true,\"Answer\":\"15\"}]}";

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
