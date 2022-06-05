const { GraphQLString } = require('graphql');
const { dbQuery } = require('../../database');
const AirplaneTypeType = require('../../types/AirplaneType');

const insertAirplaneType = {
  type: AirplaneTypeType,
  args: {
    identifier: { type: GraphQLString },
    description: { type: GraphQLString }
  },
  async resolve(_, { identifier, description }){
    let res = await dbQuery(`insert into airplane_type (identifier, description) values ('${identifier}', '${description}')`);
    return { id: res.insertId, identifier, description }
  }
};

module.exports = insertAirplaneType;