<?php

$db = mysqli_connect("localhost:3307","root","","airportdb");

if($db) {

$result2 = mysqli_select_db($db, "airportdb") or die("Doslo je do problema prilikom odabira baze...");
$sql2="SELECT * FROM employee";

//echo $sql;
$result2 = mysqli_query($db, $sql2) or die("Doslo je do problema prilikom izvrsavanja upita...");
echo "<table border='1'>
<tr>
<th>First name</th>
<th>Last name</th>
<th>Actions</th>
</tr>";
$n=mysqli_num_rows($result2);
if ($n > 0){
	while ($myrow=mysqli_fetch_row($result2)){
            echo "<tr>";
            echo "<td>" . $myrow[1] . "</td>";
            echo "<td>" . $myrow[2] . "</td>";
            echo "<td>
                <a href='#details'>DETAILS</a>
                <a href='#update'>UPDATE</a>
                <a href='#delete'>DELETE</a>
            </td>";
            echo "</tr>";
            
		}
        echo "</table>";
	}
else {
//echo "No patern rows returned<br>";
}	
}
else {
echo "<br>Nije proslo spajanje<br>";
}

?>