# Desafio Compasso UOL

# Scripts

## Event Listener
Esta classe recebe as entradas do jogador e as redireciona para o [sistema de eventos](https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html) da Unity. A grande vantagem desta abordagem é a **escalabilidade**, uma vez que permite reutilizar o código diretamente no Editor, sem precisar editá-lo. Além disso, pode ser reaproveitada facilmente em outros projetos ([loose coupling](https://en.wikipedia.org/wiki/Loose_coupling)).

## Keyboard Event
Lista de botões do teclado permitidos/tratados pelo sistema atual.

## Tween
Permite fazer a animação de movimento de um `GameObject`, em um processo de animação otimizado chamado de [Inbetweening](https://en.wikipedia.org/wiki/Inbetweening), apelidado de *Tween* pela comunidade. Também pode ser reaproveitada facilmente em outros projetos.

## Player Controller
Integra todos os scripts anteriores para fazer a solução desejada funcionar.

# Descrição do desafio

## Comportamento esperado
- O jogo inicia e fica num estado de captura de inputs (W, A, S, D ou Setas), sem simulação nem apresentação.
- O jogo guarda todas as teclas pressionadas.
- E, após pressionar a tecla R, aí sim o jogo é simulado de acordo com os comandos previamente dados.

## Critérios de análise
- Legibilidade
- Escalabilidade
- Performance
- Simplicidade

# Desenvolvedores:
- Daniel Piassi: `dandampi@gmail.com`
- Vitor Haueisen: `vitorhaueisen@gmail.com`
