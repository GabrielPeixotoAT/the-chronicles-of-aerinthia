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
        string dialogsJson = "{\"DialogsList\":[{\"Title\":\"Comerciante\",\"Message\":\"Com 400 das moedas que você tem, você compraria 2 cavalos nos estábulos. O preço dos suprimeiros que você precisa é de um décimo do preço de cada cavalo.\",\"IsQuestion\":true,\"Answer\":\"20\"},{\"Title\":\"Comerciante\",\"Message\":\"O último comprador pagou 32 moedas, e pegou 2 vezes mais suprimentos que você.\",\"IsQuestion\":true,\"Answer\":\"16\"},{\"Title\":\"Vendedor\",\"Message\":\"Um vinho que acabou de ser fabricado custa 20 moedas, um vinho envelhecido por 10 anos custa 100,  supondo que o valor do vinho suba com o tempo de forma constante, quanto custaria um vinho envelhecido por 7 anos?\",\"IsQuestion\":true,\"Answer\":\"76\"},{\"Title\":\"O vendedor diz a Léo\",\"Message\":\"Um entregador vai vir entregar as mercadorias hoje, mas não sei quanto vou ter que pagar pela entrega. O valor são 26 moedas iniciais mais 17 moedas por léguas percorridas. A viajem dura 4 léguas no total. Qual será o valor que terei que pagar no fim ao entregador?\",\"IsQuestion\":true,\"Answer\":\"94\"},{\"Title\":\"O padeiro diz a Léo\",\"Message\":\"Sobraram pães e bolos de ontem. Ninguém vai querer comprá-los hoje... Mas eu tive uma ideia, irei dar um desconto! Cada pão custa 3 moedas, e cada bolo custa 6. Ainda há doze pães e quatro bolos a serem vendidos. Para o bolo, irei vendê-lo pela metade do preço, e os pães por um terço. Qual será o valor que irei arrecadar dos pães e bolos com desconto?\",\"IsQuestion\":true,\"Answer\":\"24\"},{\"Title\":\"Um fazendeiro pede ajuda a Léo\",\"Message\":\"Nas minhas terras eu produzo trigo e farinha. Nos últimos meses entramos em uma seca das grandes que fez com que o trigo e seus derivados subissem o preço consideravelmente. O preço que eu costumava vender o saco de trigo era de 7 moedas, e o de farinha, 11. O preço hoje é o dobro disso. Eu tenho 14 sacos de trigo e 5 de farinha para vender. Quantas moedas eu irei receber caso venda meus produtos hoje?\",\"IsQuestion\":true,\"Answer\":\"306\"},{\"Title\":\"Comerciante\",\"Message\":\"O líder do vilarejo encomendou 10 espadas de ferro. Para fazê-las sem desperdiçar material eu preciso calcular quanto eu devo comprar. Para cada espada eu utilizo de uma liga metálica e para fazer essa liga eu utilizo 2 peças de ferro e 1 de carvão. Cada peça de ferro custa 6 moedas e cada peça de carvão, 2 moedas. Quantas moedas eu irei gastar de material para fazer essas espadas?\",\"IsQuestion\":true,\"Answer\":\"140\"},{\"Title\":\"Dúvida de Léo\",\"Message\":\"Dessa vez Léo gastou 18 de suas moedas para pagar as refeições e uma diária em uma pousada, o que representa um aumento de 20% do que ele gastava anteriormente. Quantas moedas Léo pagava antes desse aumento de gastos?\",\"IsQuestion\":true,\"Answer\":\"15\"}]}";

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
