<?php
    class Airport  {
        public $airport_id;
        public $iata;
        public $icao;
        public $name;

        public function __construct($airport_id = null, $iata, $icao, $name) {
            $this->airport_id = $airport_id;
            $this->iata = $iata;
            $this->icao = $icao;
            $this->name = $name;
        }


        public static function getAllAirports() {
            $airports = [];
            $db = Db::getInstance();
            $request = $db->query('SELECT * FROM airport');
                foreach($request->fetchAll() as $airp) {
                $airports[] = new Airport($airp['airport_id'], $airp['iata'], $airp['icao'], $airp['name']);
            }

            return $airports;
          }


          public static function findById($id) {
            $db = Db::getInstance();
            $id = intval($id);

            $request = $db->prepare('SELECT * FROM airport WHERE airport_id = :id');
            $request->execute(array('id' => $id));
            $airport = $request->fetch();
            
            if ($airport) {
                return new Airport($airport['airport_id'], $airport['name'], $airport['icao'], $airport['iata']);
            } else {
                return [];
            }
          }


          public function editAirportById($id, $newname, $newiata, $newicao){
            $db = Db::getInstance();
            $id = intval($id);

            $sql = "UPDATE airport SET 'name' = '$newname', 'iata' = '$newiata', 'icao' = '$newicao') VALUES WHERE airport_id = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Airport updated!";
            } else {
                $rez="Airport not updated!";;
            }
            
            return $rez; 
          }


          public function addAirport($name, $iata, $icao){
            $db = Db::getInstance();

            $sql = "INSERT INTO airport (`name`, `iata`, 'icao') VALUES ('$name', '$iata', '$icao')";

            if ($db->query($sql) == TRUE){
                $rez="Airport added!";
            } else {
                $rez="Airport not added!";;
            }
            
            return $rez; 
          }


          public static function deleteAirportById($id) {
            $db = Db::getInstance();
            $sql = "DELETE FROM Airport WHERE airport_id = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Airport deleted";
            } else {
                $rez="Deletion error!";;
            }
            
            return $rez; 
        }
    }
?>