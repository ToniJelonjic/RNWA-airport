
<?php
?>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Dodaj airline</title>
</head>
<body>
    
<div class="header">
    <h3>Dodaj airline</h3>
</div>
<a href="?controller=airline&action=add" class="button-link">Add airport</a>

<div class="ss">
  <form id="addairlineForm" method="post" action="add">
    <label for="dep">Airlinename: </label>
    <input type="text" id="airlinename" class="in" name="Airlinename">

    <label for="dep">Base_Airport: </label>
    <input type="text" id="base_airport" class="in" name="Base_Airport">

    <label for="dep">Iata: </label>
    <input type="text" id="iata" class="in" name="iata">
 
        <button type="submit" class="da">Spremi</button>
        <a href="?controller=airline&action=index"><button type="button" class="ne">Nazad</button></a>
  </form>
</div>



</body>
</html>
