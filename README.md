# Sinesp Cidadão

[SINESP Cidadão][1] é uma base de dados pública de veículos brasileiros muito útil para identificar carros ou motos roubados ou suspeitos.

# Sinesp C# API Client

Infelizmente, o governo não mantém uma API pública para realizar esse tipo de consulta. Até então, a única maneira de visualizar as informações de um determinado veículo era através do site do Sinesp respondendo a perguntas de verificação (`captchas`) para cada uma das requisições. Assim, houve a necessidade de desenvolver uma API de modo a facilitar o acesso a essas informações.

# Informações Disponíveis

Se um veículo com a placa especificada for encontrado, o servidor irá retornar com as seguintes informações:

- *codigoRetorno*: código de retorno da consulta
- *mensagemRetorno*: mensagem de retorno da consulta
- *codigoSituacao*: código da situação do veículo
- *situacao*: mensagem da situação do veículo
- *modelo*: modelo do veículo
- *marca*: marca do veículo
- *cor*: cor do veículo
- *ano*: ano de fabricação do veículo
- *anoModelo*: ano do modelo do veículo
- *placa*: placa consultada
- *data*: data e hora da consulta
- *uf*: estado ou unidade federativa do veículo
- *municipio*: município ou cidade do veículo
- *chassi*: chassi do veículo

Essas informações estarão disponíveis por meio de um `array associativo` ou como `atributo` do objeto.

# Requisitos

- C#
- Visual Studio


# Sinesp Python API Client

Uma implementação em linguagem `Python` encontra-se disponível no seguinte repositório: https://github.com/victor-torres/sinesp-client/

# Sinesp PHP API Client

Uma implementação em linhagem `PHP` encontra-se disponível no seguinte repositório: https://github.com/chapeupreto/sinesp/

# Agradecimentos

Agradecimentos ao [@victor-torres](https://github.com/victor-torres) e seus contribuidores por disponibilizar a [implementação em Python da API](https://github.com/victor-torres/sinesp-client/), a qual serviu como base para o surgimento desta em linguagem [PHP](http://www.php.net/).

Agradecimentos também ao [@ricardotominaga](https://github.com/ricardotominaga) por disponibilizar a secret key.

[1]: https://www.sinesp.gov.br/sinesp-cidadao "Sinesp Cidadão"
