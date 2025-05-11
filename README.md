# Trilhas da Memória

## Descrição do Projeto
Trilhas da Memória é um jogo educativo de memória desenvolvido em C# utilizando Windows Forms. O jogo desafia os jogadores a encontrar pares de cartas correspondentes, exercitando a memória e a concentração.

## Funcionalidades
- Seleção de nível de dificuldade (Fácil, Médio, Difícil)
- Grade de cartas com lógica de memória
- Contagem de tentativas e tempo
- Verificação de acertos e mensagens de vitória
- Sistema de reinício de jogo

## Níveis de Dificuldade
- **Fácil**: 4x4 = 16 cartas (8 pares)
- **Médio**: 6x4 = 24 cartas (12 pares)
- **Difícil**: 6x6 = 36 cartas (18 pares)

## Requisitos do Sistema
- Windows 7 ou superior
- .NET 6.0 ou superior
- Resolução mínima de tela: 800x600

## Como Jogar
1. Inicie o aplicativo e selecione o nível de dificuldade
2. Clique nas cartas para virá-las
3. Tente encontrar todos os pares correspondentes
4. O jogo termina quando todos os pares forem encontrados

## Estrutura do Projeto
- **FormSelecaoNivel**: Tela inicial para seleção do nível de dificuldade
- **FormJogo**: Tela principal onde ocorre o jogo
- **Carta**: Classe que representa cada carta do jogo
- **Dificuldade**: Enum que define os níveis de dificuldade

## Desenvolvimento
Este projeto foi desenvolvido como parte de uma atividade educativa para demonstrar conceitos de programação em C# e desenvolvimento de interfaces gráficas com Windows Forms.

## Como Testar o Projeto

### Requisitos para Teste
- Windows 7 ou superior
- Visual Studio 2019 ou superior (Community, Professional ou Enterprise)
- .NET 6.0 SDK instalado

### Passos para Testar

1. **Abrir o Projeto no Visual Studio:**
   - Abra o Visual Studio
   - Selecione 'Arquivo' > 'Abrir' > 'Projeto/Solução'
   - Navegue até a pasta do projeto e selecione o arquivo 'TrilhasDaMemoria.sln'

2. **Compilar o Projeto:**
   - No Visual Studio, clique em 'Compilar' > 'Compilar Solução' (ou pressione F6)
   - Verifique se não há erros de compilação na janela 'Saída'

3. **Executar o Projeto:**
   - Clique em 'Depurar' > 'Iniciar Sem Depuração' (ou pressione Ctrl+F5)
   - O jogo deve iniciar na tela de seleção de nível

4. **Testar as Funcionalidades:**
   - Teste os diferentes níveis de dificuldade (Fácil, Médio, Difícil)
   - Verifique se as cartas são viradas corretamente ao clicar
   - Verifique se os pares são identificados corretamente
   - Teste o botão de reiniciar o jogo
   - Verifique se a contagem de tentativas e tempo está funcionando

5. **Criar o Instalador (Opcional):**
   - Após compilar o projeto com sucesso, você pode criar um instalador usando a classe 'Instalador'
   - Adicione um botão ou opção de menu para chamar o método 'Instalador.CriarInstalador(caminho)'
   - Isso criará um pacote de instalação no caminho especificado

### Comandos para Teste via Linha de Comando

Se preferir usar a linha de comando:

```bash
# Navegar até a pasta do projeto
cd /caminho/para/TrilhasDaMemoria

# Compilar o projeto
dotnet build

# Executar o projeto
dotnet run
```

### Solução de Problemas

- **Erro de referência ausente:** Verifique se todas as referências do projeto estão corretamente configuradas
- **Erro de compilação:** Verifique se o .NET 6.0 SDK está instalado corretamente
- **Erro de execução:** Verifique se o Windows Forms está habilitado no arquivo do projeto (.csproj)
