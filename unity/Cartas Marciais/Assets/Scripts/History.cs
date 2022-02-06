using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class History : MonoBehaviour
{
    public string[] histories = new string[4];

    TMP_Text tmp;


    public void Start()
    {
        tmp = GetComponent<TMP_Text>();

        histories[0] = "S�mbolo de for�a e determina��o, Lee, o panda, representa toda a conex�o com a sabedoria oriental atrav�s de seus golpes de kung fu. Ele se destaca principalmente por sua sabedoria t�o grande que pode ser comparada � de Ta Mo, um antigo monge chin�s que desenvolveu a arte do Kung Fu a partir da observa��o dos animais � como se movimentavam, as posi��es em que lutavam e tamb�m como se defendiam. Lee � um panda que domina o equil�brio perfeito entre mente e corpo na hora de uma luta.";
        histories[1] = "Nascido na Austr�lia continental, Henry, o canguru, � o fen�meno do boxe. Assim como outros cangurus selvagens, Henry tem tend�ncia para preferir a m�o esquerda quando realiza suas tarefas, mas isso n�o o impede de usar com maestria sua m�o direita para golpear os advers�rios. Com sua velocidade assustadora e seus saltos que podem chegar at� 1,8 metros de altura, Henry se destaca quando o assunto � desviar de golpes e nocautear seus oponentes.";
        histories[2] = "Silva, o tatu-bola, � um dos melhores lutadores de capoeira do Brasil. Assim como outros de sua esp�cie, apresenta como uma das principais caracter�sticas a capacidade de se fechar na forma de uma bola ao se sentir amea�ado, o que protege as partes moles de seu corpo contra o ataque de predadores. Como um bom lutador de capoeira, Silva possui movimentos �geis e intric�veis e � um oponente dif�cil de ser derrotado.";
        histories[3] = "Adel � a poupa-euro-asi�tica mais perigosa de Israel. Com seu bico comprido e cavado, asas esvoa�antes e sua bela cauda, Adel � perfeita para por em pr�tica as t�cnicas de luta do krav maga. Seu voo r�pido e direto � perfeito para esquiva e ataques desprevenidos que deixam qualquer oponente tonto.";
    }

    public void Troca(int i)
    {
        tmp.text = histories[i];
    }


}
