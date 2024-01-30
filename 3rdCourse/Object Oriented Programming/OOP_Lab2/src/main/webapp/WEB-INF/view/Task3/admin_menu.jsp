<%--
  Created by IntelliJ IDEA.
  User: Максим
  Date: 25.10.2022
  Time: 21:52
  To change this template use File | Settings | File Templates.
  //http://localhost:8080/OOP_Lab2_war/logout/
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
  <meta charset="UTF-8">
  <title>Site</title>

</head>
<body>

<h1> Вход выполнен </h1>
<h2> Добро пожаловать Admin </h2>

<p>Date: ${date}</p>
<a href="<c:url value='${pageContext.request.contextPath}/' />">Logout</a>
</body>

</html>
