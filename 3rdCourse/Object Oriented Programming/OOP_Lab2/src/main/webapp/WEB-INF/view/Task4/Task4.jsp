
<%@ page contentType="text/html; charset=UTF-8" language="java" %>
<html>
<head>
    <meta charset="UTF-8">
    <title>Task4</title>

</head>
<body>
<h1 style="text-align:center">Exchange rates</h1>
<br>
<br>


<form action="${pageContext.request.contextPath}/task4" method = "POST">

    <label for="chooser_id">Choose something</label><br>
    <select id="chooser_id" name="chooser">
        <option value="Currency">Currency</option>
        <option value="Precious metals">Precious metals</option>
    </select>
    <br><br>
    <p>
        Date format: day/month/year<br>
        if you want to see the exchange rate for one day, fill in only the "Date1".<br>
        If you'd like to see prices for a period of time,fill both dates and id field <br>

        id currency:<br>
        GBP - R01035 <br>
        USD - R01235 <br>
        EUR - R01239<br><br>

    </p>
    <br>

    <label for="date1">Date1</label><br>
    <input type="text" id="date1" name="field_date1"><br>

    <label for="date2">Date2</label><br>
    <input type="text" id="date2" name="field_date2"><br>

    <label for="id">Id</label><br>
    <input type="text" id="id" name ="field_id"><br>
    <input type="submit" value="Enter">
</form>

</body>
</html>
