# FilmSpinAPI

API construída com Minimal APIs do .NET que consulta a API do TMDb e fornece filmes aleatórios formatados para uso direto no [FilmSpin](https://github.com/rafaelwnk/FilmSpin) e no [FilmSpinBot](https://github.com/rafaelwnk/FilmSpinBot). O objetivo é centralizar a lógica de busca e formatação, evitando duplicação de código entre as plataformas.

## Tecnologias Utilizadas

- .NET 8

## Instalação e Execução
Siga os passos abaixo para configurar e executar o projeto localmente.

### Pré-requisitos
Antes de iniciar, certifique-se de ter os seguintes itens instalados:

- [.NET](https://dotnet.microsoft.com/en-us/download)

### 1. Clone o repositório:
```bash
git clone https://github.com/rafaelwnk/FilmSpinAPI
cd FilmSpinAPI
```

### 2. Restaure as dependências::
```bash
dotnet restore
```

### 3. Execute o projeto:
```bash
dotnet run
```

### 4. A API estará disponível por padrão em:
```bash
http://localhost:5149
```

## Contribuições

Se você tiver alguma sugestão de melhoria, ideia nova ou perceber algo que pode ser ajustado:

    1.Faça um fork do repositório

    2.Crie uma nova branch: git checkout -b feature

    3.Faça um commit: git commit -m 'feat: new feature'

    4.Faça o push para a branch : git push origin feature

    5.Abra um pull request