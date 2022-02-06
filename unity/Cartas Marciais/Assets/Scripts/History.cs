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

        histories[0] = "Símbolo de força e determinação, Lee, o panda, representa toda a conexão com a sabedoria oriental através de seus golpes de kung fu. Ele se destaca principalmente por sua sabedoria tão grande que pode ser comparada à de Ta Mo, um antigo monge chinês que desenvolveu a arte do Kung Fu a partir da observação dos animais — como se movimentavam, as posições em que lutavam e também como se defendiam. Lee é um panda que domina o equilíbrio perfeito entre mente e corpo na hora de uma luta.";
        histories[1] = "Nascido na Austrália continental, Henry, o canguru, é o fenômeno do boxe. Assim como outros cangurus selvagens, Henry tem tendência para preferir a mão esquerda quando realiza suas tarefas, mas isso não o impede de usar com maestria sua mão direita para golpear os adversários. Com sua velocidade assustadora e seus saltos que podem chegar até 1,8 metros de altura, Henry se destaca quando o assunto é desviar de golpes e nocautear seus oponentes.";
        histories[2] = "Silva, o tatu-bola, é um dos melhores lutadores de capoeira do Brasil. Assim como outros de sua espécie, apresenta como uma das principais características a capacidade de se fechar na forma de uma bola ao se sentir ameaçado, o que protege as partes moles de seu corpo contra o ataque de predadores. Como um bom lutador de capoeira, Silva possui movimentos ágeis e intricáveis e é um oponente difícil de ser derrotado.";
        histories[3] = "Adel é a poupa-euro-asiática mais perigosa de Israel. Com seu bico comprido e cavado, asas esvoaçantes e sua bela cauda, Adel é perfeita para por em prática as técnicas de luta do krav maga. Seu voo rápido e direto é perfeito para esquiva e ataques desprevenidos que deixam qualquer oponente tonto.";
    }

    public void Troca(int i)
    {
        tmp.text = histories[i];
    }


}
