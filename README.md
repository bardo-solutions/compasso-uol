# Desafio Compasso UOL

## Event Listener
Esta classe recebe as entradas do jogador e as redireciona para o [sistema de eventos](https://docs.unity3d.com/ScriptReference/Events.UnityEvent.html) da Unity. A grande vantagem desta abordagem é a **escalabilidade**, uma vez que permite reutilizar o código diretamente no Editor, sem precisar editá-lo.

## Keyboard Event
Lista de botões do teclado permitidos/tratados pelo sistema.

## Tween
Permite fazer a animação de movimento do cubo, em um processo de animação otimizado chamado de [Inbetweening](https://en.wikipedia.org/wiki/Inbetweening), apelidado de *Tween* pela comunidade.

## Player Controller
Integra todos os scripts anteriores para fazer a solução desejada funcionar.
