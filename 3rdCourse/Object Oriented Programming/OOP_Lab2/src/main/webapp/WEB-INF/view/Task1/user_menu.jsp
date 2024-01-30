<%--
  Created by IntelliJ IDEA.
  User: Максим
  Date: 25.10.2022
  Time: 21:52
  To change this template use File | Settings | File Templates.
--%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <meta charset="UTF-8">
    <title>Site</title>

</head>
<body>
<h1> Вход выполнен </h1>
<h2> Добро пожаловать User </h2>
<p>Date: ${date}</p>
<a href="<c:url value='${pageContext.request.contextPath}/' />">Logout</a>
</body>
</html>
