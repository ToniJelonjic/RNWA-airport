<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" type="text/css" href="../index.css">
    <title>Pregled airline</title>
</head>

<body>

    <div class="header">
        <h3>Pregled airline</h3>
    </div>
    <a href="?controller=airline&action=add" class="button-link">Add airline</a>

    <div class="ss">
        <table class="data-table">
            <tr>
                <th>airline_id</th>
                <th>airlinename</th>
                <th>base_airport</th>
                <th>iata</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
            <?php foreach ($data['airlines'] as $row) : ?>
                <tr>
                    <td><?php echo $row->airline_id ?></td>
                    <td><?php echo $row->airlinename ?></td>
                    <td><?php echo $row->base_airport ?></td>
                    <td><?php echo $row->iata ?></td>
                    <td><a href="airlines_edit?airline_id=<?php echo $row->airline_id ?>" class="edit-btn"> Edit</a>
                    </td>
                    <td>
                        <form action="airlines_delete" method="post">
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