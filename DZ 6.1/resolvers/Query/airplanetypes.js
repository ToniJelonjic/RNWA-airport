const { GraphQLList } = require('graphql');
const { dbQuery } = require('../../database');
const AirplaneTypeType = require('../../types/AirplaneType');

const fieldsAirplaneTypes = {
  type: new GraphQLList(AirplaneTypeType),
  async resolve(_, {}){
    let res = await dbQuery(`SELECT * FROM airplane_type`);
    return res;
  }
};

module.exports = fieldsAirplaneTypes;
