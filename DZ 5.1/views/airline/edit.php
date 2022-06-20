<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Uredi airline</title>
</head>
<body>
    
<div class="header">
    <h3>Uredi airline</h3>
</div>

<div class="ss">
  <form id="addDeptForm" method="POST" action="edit">
    <label for="dep">airlineName: </label>
    <input type="text" id="airlinename" class="in" name="airlinename">

    <label for="dep">Iata: </label>
    <input type="text" id="iata" class="in" name="iata">

    <label for="dep">Base airport: </label>
    <input type="text" id="base_airport" class="in" name="base_airport">

    <label for="grp">ID:</label>
    <input type="text" id="airlineId" class="in" name="airlineId">
    
        <button type="button" class="da" onclick="">Spremi</button>
        <a href="?controller=airline&action=index"><button type="button" class="ne">Nazad</button></a>
  </form>
</div>

</body>
</html>
