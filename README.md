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

## Utilização da API

### Exemplos de uso:

**1. Film**

`POST v1/films`

Retorna um filme aleatório baseado nos filtros fornecidos no body da requisição: genre, decade e rating

**Exemplo de requisição:**

```bash
curl -X POST "http://localhost:5149/v1/films" \
     -H "Content-Type: application/json" \
     -d '{
            "genre": "53",
            "decade": "1990",
            "rating": "8"
        }'
```

**Exemplo de resposta:**

```bash
{
    "data": {
        "id": 807,
        "title": "Seven - Os Sete Crimes Capitais",
        "genres": [
            {
                "id": 80,
                "name": "Crime"
            },
            {
                "id": 9648,
                "name": "Mistério"
            },
            {
                "id": 53,
                "name": "Thriller"
            }
        ],
        "overview": "Quando, a ponto de se aposentar, o detetive William Somerset aborda o último caso com a ajuda do recém-transferido David Mills, eles descobrem uma série de assassinatos. Logo percebem que estão lidando com um assassino que tem como alvo pessoas que ele acredita representar os sete pecados capitais.",
        "posterPath": "https://image.tmdb.org/t/p/w500//cNFCNa5jUYmFmSpCg7dJ3jWd22d.jpg",
        "releaseYear": "1995",
        "voteAverage": 8.4
    },
    "isSuccess": true,
    "message": ""
}
```

**2. Genres**

`GET v1/genres`

Retorna todos os gêneros de filmes disponíveis

**Exemplo de requisição:**

```bash
curl -X GET "http://localhost:5149/v1/genres"
```

**Exemplo de resposta:**

```bash
{
    "data": [
        {
            "id": 28,
            "name": "Ação"
        },
        {
            "id": 12,
            "name": "Aventura"
        },
        {
            "id": 16,
            "name": "Animação"
        },
        {
            "id": 35,
            "name": "Comédia"
        },
        {
            "id": 80,
            "name": "Crime"
        },
        {
            "id": 99,
            "name": "Documentário"
        },
        {
            "id": 18,
            "name": "Drama"
        },
        {
            "id": 10751,
            "name": "Família"
        },
        {
            "id": 14,
            "name": "Fantasia"
        },
        {
            "id": 36,
            "name": "História"
        },
        {
            "id": 27,
            "name": "Terror"
        },
        {
            "id": 10402,
            "name": "Música"
        },
        {
            "id": 9648,
            "name": "Mistério"
        },
        {
            "id": 10749,
            "name": "Romance"
        },
        {
            "id": 878,
            "name": "Ficção científica"
        },
        {
            "id": 10770,
            "name": "Cinema TV"
        },
        {
            "id": 53,
            "name": "Thriller"
        },
        {
            "id": 10752,
            "name": "Guerra"
        },
        {
            "id": 37,
            "name": "Faroeste"
        }
    ],
    "isSuccess": true,
    "message": ""
}
```

## Contribuições

Se você tiver alguma sugestão de melhoria, ideia nova ou perceber algo que pode ser ajustado:

    1.Faça um fork do repositório

    2.Crie uma nova branch: git checkout -b feature

    3.Faça um commit: git commit -m 'feat: new feature'

    4.Faça o push para a branch : git push origin feature

    5.Abra um pull request