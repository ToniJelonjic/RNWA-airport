<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <script src="scripts\index.js"></script>
    <title>Pregled airport</title>
</head>
<body>
    
<div class="header">
    <h3>Pregled airport</h3>
</div>

<div class="ss">
  <table class="data-table">
    <tr>
        <th>airport_id</th>
        <th>name</th>
        <th>icao</th>
        <th>iata</th>
        <th>Edit</th>
        <th>Delete</th>
    </tr>
    <?php foreach ($data['airports'] as $row) : ?>
        <tr>
            <td><?php echo $row->airport_id ?></td>
            <td><?php echo $row->name ?></td>
            <td><?php echo $row->icao ?></td>
            <td><?php echo $row->iata ?></td>
            <td><a href="airports_edit?airport_id=<?php echo $row->airport_id ?>" class="edit-btn"> Edit</a>
            </td>
            <td>
                <form action="airports_delete" method="post">
                    <input type="hidden" name="_method" value="DELETE">
                    <input type="submit" value="Delete" class="delete-btn">
                </form>
            </td>
        </tr>
    <?php endforeach ?>
  </table>
</div>

</body>
</html>