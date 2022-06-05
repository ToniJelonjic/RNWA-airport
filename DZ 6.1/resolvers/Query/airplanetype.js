const { GraphQLInt } = require('graphql');
const { dbQuery } = require('../../database');
const AirplaneTypeType = require('../../types/AirplaneType');

const fieldsAirplaneType = {
  type: AirplaneTypeType,
  args: {
    type_id: { type: GraphQLInt }
  },
  async resolve(_, { type_id }){
    let res = await dbQuery(`SELECT * FROM airplane_type WHERE id = ${type_id}`);
    return res[0];
  }
};

module.exports = fieldsAirplaneType;
