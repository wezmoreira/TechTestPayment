# API REST com Entity Framework

![Badge](http://img.shields.io/static/v1?label=STATUS&message=DEVELOPMENT&color=yellow&style=for-the-badge)

<p align="center">API teste tecnico Pottencial<p>

## Ojetivos do projeto!
- SOLID
- CQRS
- DDD
- Api REST
- Testes unitários
- Padronização de retorno
- Banco de dados em memória
- Mapeamento com Fluent Mapping
- Paginação

## Documentação

| Path | Descrição |
|---|---|
|/swagger | Documentação (Verifique se a rota esta correta) |


### Retorno padronizado

```
{
  "success": true,
  "message": "string",
  "data": "string"
}
```


#### Os Status só podem seguir a seguinte ordem.

- De: AGUARDANDO_PAGAMENTO Para: PAGAMENTO_APROVADO
- De: AGUARDANDO_PAGAMENTO Para: CANCELADA
- De: PAGAMENTO_APROVADO Para: ENVIADO_PARA_TRANSPORTADORA
- De: PAGAMENTO_APROVADO Para: CANCELADA
- De: ENVIADO_PARA_TRANSPORTADORA. Para: ENTREGUE


### Exemplo de Request Order
#### é necessário informar o Id do Seller e o Skuid do item que é gerado automaticamente!

```
{
    "sellerid": 1,
    "items": [
        {
            "skuid": "Inserir o skuid do item criado",
            "amount": 1
        },
        {
            "skuid": "Inserir o skuid do item criado",
            "amount": 1
        }
    ]
}
```

## O TESTE
- Construir uma API REST utilizando .Net Core, Java ou NodeJs (com Typescript);
- A API deve expor uma rota com documentação swagger (http://.../api-docs).
- A API deve possuir 3 operações:
  1) Registrar venda: Recebe os dados do vendedor + itens vendidos. Registra venda com status "Aguardando pagamento";
  2) Buscar venda: Busca pelo Id da venda;
  3) Atualizar venda: Permite que seja atualizado o status da venda.
     * OBS.: Possíveis status: `Pagamento aprovado` | `Enviado para transportadora` | `Entregue` | `Cancelada`.
- Uma venda contém informação sobre o vendedor que a efetivou, data, identificador do pedido e os itens que foram vendidos;
- O vendedor deve possuir id, cpf, nome, e-mail e telefone;
- A inclusão de uma venda deve possuir pelo menos 1 item;
- A atualização de status deve permitir somente as seguintes transições: 
  - De: `Aguardando pagamento` Para: `Pagamento Aprovado`
  - De: `Aguardando pagamento` Para: `Cancelada`
  - De: `Pagamento Aprovado` Para: `Enviado para Transportadora`
  - De: `Pagamento Aprovado` Para: `Cancelada`
  - De: `Enviado para Transportador`. Para: `Entregue`
- A API não precisa ter mecanismos de autenticação/autorização;
- A aplicação não precisa implementar os mecanismos de persistência em um banco de dados, eles podem ser persistidos "em memória".
