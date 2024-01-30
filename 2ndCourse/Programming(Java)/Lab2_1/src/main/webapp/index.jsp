<%--<%@ page contentType="text/html; charset=UTF-8" pageEncoding="UTF-8" %>--%>
<%--<!DOCTYPE html>--%>
<%--<html>--%>
<%--<head>--%>
<%--    <title>JSP - Hello World</title>--%>
<%--</head>--%>
<%--<body>--%>
<%--<h1><%= "Hello World!" %>--%>
<%--</h1>--%>
<%--<br/>--%>
<%--<a href="hello-servlet">Hello Servlet</a>--%>
<%--</body>--%>
<%--</html>--%>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
<form action="http://localhost:8080/Lab2-1.0-SNAPSHOT/task3" method = "POST">
    <h1>AUTH</h1>
    <hr>
    <label for="log">Login</label><br>
    <input type="text" id="log" name="login"><br><br>
    <label for="pass">Password</label><br>
    <input type="password" id="pass" name="password"><br><br><hr><br>
    <input type="submit" value="Enter">
    <p><a href="http://localhost:8080/Lab2-1.0-SNAPSHOT/task1"></a></p>
</form>
</body>
</html>