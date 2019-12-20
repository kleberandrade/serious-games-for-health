using UnityEngine;

public class NpcGenerator : MonoBehaviour {
	/*
  - lista de sprites
  - lista de arquivos de texto
  - lista de nomes

  Fazer um ramdom de quantos npc irá spawnar dentro do jogo(a definir).

  Ao criar o npc, adicionar ao mesmo, o script de npc,
  sprite relacionado, dar nome ao mesmo, adicionar arquivo de texto nele.
  */

	public int m_amountSpawnNpcs;
	public GameObject m_NpcPrefab;
	public Sprite[] m_NpcSprites;

	private void Start() {
		generateNPC();
	}

	void generateNPC() {
		for (int i = 0; i < m_amountSpawnNpcs; i++) {
			GameObject npc = Instantiate(m_NpcPrefab);
			npc.name = "npc" +	i;
			//Adicionando os componentes
			npc.AddComponent<SpriteRenderer>();
			npc.AddComponent<NpcController>();

			//Adicionandos propriedades
			npc.GetComponent<SpriteRenderer>().sprite = m_NpcSprites[Random.Range(0, m_NpcSprites.Length)];
		}
	}

}