# Raycast Unity
Exemplo implementação Raycast

## Definição: 

Raycast em Unity é uma função física que projeta um Ray na cena, devolvendo um valor booleano se um alvo foi atingido com sucesso. Quando isso acontece, informações sobre o hit, como a distância, posição ou uma referência ao Transform do objeto, podem ser armazenadas em uma variável Raycast Hit para uso posterior.

## Estrutura do Raycast

Um Raycast é Composto por três elementos:

- uma variável do tipo  **Ray**
- uma variável do tipo **RaycastHit**
- a função Raycast

### Ray

Consiste em uma estrutura de dados que representa um ponto de origem e uma direção.

A origem consiste em um Vector3 que determina onde o Ray começa, enquanto a direção determina a trajetória e consiste em um Vector3 normalizado, ou seja, sua magnitude é limitada para 1.

Formas de declarar um Ray

- Cria um raio a partir de um objeto de origem para uma direção normalizada ( eixo Z)
<code>
Ray ray = new Ray(transform.position, transform.forward);
</code>

- Criar um raio do centro do Viewport
<code>
Ray ray = Camera.main.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));
</code>

- Criar um raio a partir da posição do mouse
<code>
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
</code>


### RaycastHit

Consiste em uma estrutura de dados que armazena as informações sobre a colisão, seguem as propriedades retornadas

- point: posição onde o raio acertou
- distance: distancia da origem até a colisão
- collider: o colisor que foi atingido pelo raio
- trasnform: a transform do objeto atingido

### Raycast

O Raycast pode ser instanciado de diferentes formas que permitem customizar o lançamento, em sua forma simplificada é efetuado o lançamento do Ray e recebida uma saída ( representada pelo parametro **out**)
<code>
   Ray ray = new Ray(transform.position, transform.forward);
    RaycastHit hitData;
    Physics.Raycast(ray, out hitData);
</code>
 É possível também por meio da sobrecarga de métodos efetuar o lançamento por outros meios:
![image](https://github.com/alinefbrito/Raycast_Unity/assets/15115116/315cdea4-8f7f-4433-bc89-6b77d6e0ad9f)

 - Informando apenas o Ray, normalmente utilizado dentro de uma condicional onde é necessário apenas saber se houve sucesso ( o retorno é **TRUE**)
 <code>
 if (Physics.Raycast(ray)) 
{ 
    // O Ray atingiu algo
}
 </code>

 - Informando o Ray e a distância máxima
 <code>
 Physics.Raycast(ray, 10);
 </code>
  - Informando o Ray, recebendo o RaycastHit, definindo a distância máxima, a camada e  o comportamento em relação às Triggers
  <code>
  Physics.Raycast(ray, out hitData, 10, layerMask, QueryTriggerInteraction.Ignore);
  </code>
