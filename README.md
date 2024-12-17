# WebAppRegra

Aplicação web criado para o desafio de Analista Desenvolvedor.

- Linguagem: C#
- Framework: Asp.Net Core 6
- Arquitetura: MVC
- Banco de Dados: SQL Server 2022
- ORM: Entity Framework Core 7.0

## Passo a Passo: Buildar na Máquina Local

### Criando Database e conectando Database na Aplicação

No Visual Code 2022, digitar Ctrl + Alt + S para abrir o Server Explorer

Vá em Connect to Database

![Imagem do WhatsApp de 2024-12-17 à(s) 00 22 14_e46b8504](https://github.com/user-attachments/assets/fa2c2278-fef4-4193-86b7-de9d1d3d5a9c)

No Formulário que segue, insira "." no campo "Server Name":

![image](https://github.com/user-attachments/assets/d1e094ea-2c7d-4ef2-a057-1a6a954dfcff)

Marque a opção "Trust Server Certificate":

![image](https://github.com/user-attachments/assets/c5a1b9e8-a0dd-4236-b045-bd0c00efb647)

No campo "Select or enter a database name", insira o nome do banco de dados:
![Imagem do WhatsApp de 2024-12-17 à(s) 00 22 13_422c9987](https://github.com/user-attachments/assets/b060b846-c6c3-437d-b344-9376b1fa6906)

Em seguida, será perguntado se você quer criar uma database nova, clique em "Yes":

![image](https://github.com/user-attachments/assets/92508180-f436-4cd6-ac07-f681cb095479)

Do lado direito abrirá as propriedades do banco de dados recém criado, copie a Connection String:

![image](https://github.com/user-attachments/assets/1327c086-8be5-44cc-9588-6f866d60b70a)

Abra o arquivo appsettings.json e insira a connection string como valor dentro da chave "DefaultConnection". Salve o arquivo:

![Imagem do WhatsApp de 2024-12-17 à(s) 00 22 12_a25cf780](https://github.com/user-attachments/assets/29ef27bb-fce8-43e3-bde6-fde04a134f8e)


### Instalando Dependências

Tools > NuGet Package Manager > Manage NuGet Packages for Solution:

![image](https://github.com/user-attachments/assets/fb4efee7-8f18-4fb5-9211-e8fdfd762ea4)

Instale o EF Core (versão 7.0), EF Core SQL Server (versão 7.0) e EF Core Tools (versão 7.0):

![Imagem do WhatsApp de 2024-12-17 à(s) 00 22 12_4f195e85](https://github.com/user-attachments/assets/de3d8e24-f112-4b33-a9ed-81bd131cb6f4)

### Criando Migrations

Tools > NuGet Package Manager > Package Manager Console:

![image](https://github.com/user-attachments/assets/c15c2162-ef64-4a31-a6c1-9263ac4b2496)

Execute o comando "Add-Migration FirstMigration":

![Imagem do WhatsApp de 2024-12-17 à(s) 00 24 48_a95696a5](https://github.com/user-attachments/assets/074b07a7-7178-4408-b7d1-77ef4ec7458e)

Execute o comando "Update-Database":
![Imagem do WhatsApp de 2024-12-17 à(s) 00 24 48_bf924ef5](https://github.com/user-attachments/assets/8a3db2eb-e392-4cd1-bc26-914e24073013)

### Executando a Aplicação

Por fim, Buildar e Iniciar a Aplicação:

![image](https://github.com/user-attachments/assets/72db4f67-a732-4bd3-a480-5d37b59e29f1)
