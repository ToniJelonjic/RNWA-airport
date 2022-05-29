<?php
    class AirportReachable  {
        private $AirportId;
        private $Hops;


        public function __construct($AirportId = null, $Hops) {
            $this->Hops = $Hops;
        }


        public function getAirportReachableId() {
            return $this->AirportId;
        }

        public function getHops() {
            return $this->Hops;
        }
        public function setHops($hops) {
            return $this->Hops = $hops;
        }

        public static function getAllAirportReachables() {
            $airport_reachables = [];
            $db = Db::getInstance();
            $request = $db->query('SELECT * FROM airport_reachable');
                foreach($request->fetchAll() as $airp) {
                $list[] = new AirportReachable($airp['AirportId'], $airp['Hops']);
            }

            return $airport_reachables;
          }


          public static function findById($id) {
            $db = Db::getInstance();
            $id = intval($id);

            $request = $db->prepare('SELECT * FROM airport_reachable WHERE AirportId = :id');
            $request->execute(array('id' => $id));
            $airport_reachable = $request->fetch();
            
            if ($airport_reachable) {
                return new AirportReachable($airport_reachable['AirportId'], $airport_reachable['Hops'], $airport_reachable['Hops'], $airport_reachable['ModifiedDate']);
            } else {
                return [];
            }
          }


          public function editAirportReachableById($id, $newHops){
            $db = Db::getInstance();
            $id = intval($id);

            $sql = "UPDATE airport_reachable SET 'Hops' = '$newHops') VALUES WHERE AirportId = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="AirportReachable updated!";
            } else {
                $rez="AirportReachable not updated!";;
            }
            
            return $rez; 
          }


          public function addAirportReachable($Hops){
            $db = Db::getInstance();

            $sql = "INSERT INTO airport_reachable (`Hops`) VALUES ('$Hops')";

            if ($db->query($sql) == TRUE){
                $rez="AirportReachable added!";
            } else {
                $rez="AirportReachable not added!";;
            }
            
            return $rez; 
          }


          public static function deleteAirportReachableById($id) {
            $db = Db::getInstance();
            $sql = "DELETE FROM airport_reachable WHERE AirportId = '$id'";

            if ($db->query($sql) == TRUE){
                $rez="AirportReachable deleted";
            } else {
                $rez="Deletion error!";;
            }
            
            return $rez; 
        }
    }
?>