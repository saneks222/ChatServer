# ChatServer
![image](https://user-images.githubusercontent.com/66480963/189644463-8ef2c67a-afca-415c-8208-8e7da79d9312.png)
1) Auth/login - принимает логен и пароль в ответ отдает  JWT токен для авторизации.
2) Auth/register - принмает логин, почту , пароль и созщдает нового пользователя с введенными данными
3) Message/SendMessage - принмсет id чата и текст сообщение отправлет сообщение в данный чат 
4) Messanger/GetChats - при вызове метода возвращаеться коолеция обьектов чатов в которых состоит пользователь 
5) Messanger/CreateNewChat - принимает название и коллецию идентификаторов пользователей. создает чат с данным названием и добавляет в него текущего авторезированного полльзователя и всех пользователей переданных в коллекции
6) Messanger/GetAllMessageByChatId - получает коллецию обьектов сообщений находящихся в чате
