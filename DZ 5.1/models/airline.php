<?php
    class Airline  {
        public $airline_id;
        public $iata;
        public $airlinename;
        public $base_airport;

        public function __construct($airline_id = null, $iata, $airlinename, $base_airport) {
            $this->airline_id = $airline_id;
            $this->iata = $iata;
            $this->airlinename = $airlinename;
            $this->base_airport = $base_airport;
        }

        public static function getAllAirlines() {
            $Airlines = [];
            $db = Db::getInstance();
            $request = $db->query('SELECT * FROM airline');
                foreach($request->fetchAll() as $cult) {
                $Airlines[] = new Airline($cult['airline_id'], $cult['iata'], $cult['airlinename'], $cult['base_airport']);
            }

            return $Airlines;
          }


          public static function findById($id) {
            $db = Db::getInstance();

            $request = $db->prepare('SELECT * FROM airline WHERE airline_id = :id');
            $request->execute(array('id' => $id));
            $Airline = $request->fetch();
            
            if ($Airline) {
                return new Airline($Airline['airline_id'], $Airline['iata'], $Airline['airlinename'], $Airline['base_airport']);
            } else {
                return [];
            }
          }


          public function editAirlineById($id, $newiata, $newairlinename, $newbase_airport){
            $db = Db::getInstance();

            $sql = "UPDATE Airline SET 'iata' = '$newiata', 'airlinename' = '$newairlinename', 'Base_airport' = '$newbase_airport') VALUES WHERE airline_id = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Airline updated!";
            } else {
                $rez="Airline not updated!";;
            }
            
            return $rez; 
          }


          public static function addAirline($airline_id, $iata, $airlinename){
            $db = Db::getInstance();

            $sql = "INSERT INTO airline (`airline_id`, `iata`, `airlinename`, ') VALUES ('$airline_id', '$iata', '$airlinename')";

            if ($db->query($sql) == TRUE){
                $rez="Airline added!";
            } else {
                $rez="Airline not added!";;
            }
            
            return $rez; 
          }


          public static function deleteAirlineById($id) {
            $db = Db::getInstance();
            $sql = "DELETE FROM airline WHERE airline_id = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="Culture deleted";
            } else {
                $rez="Deletion error!";;
            }
            
            return $rez; 
        }
    }
?>