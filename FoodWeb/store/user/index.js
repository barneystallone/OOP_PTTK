

// state
const state = () => ({
    token: '',
    role: ''
  })
  // mutations
  const mutations = {
    SET_TOKEN (state, token){
      state.token = token
    },
    REMOVE_TOKEN(state){
      state.token = ''
    },
    SET_ROLE(state, roleName){
      state.role = roleName
    }
  }
  // getters
  const getters = {
    getToken(state){
      return state.token;
    },
    isAuthen(state){
      return state.token !== ''
    },
    isLogin(state){
      return state.token === ''
    },
    getRole(state){
      return state.role
    },
    isUser(state){
    
      return state.token !== ''
      
    },
    isView(state){
      return state.token === ''
  
    },
  }
  // actions
  const actions = {
    setToken({commit}, token){
      commit('SET_TOKEN', token)
    },
    logout({commit}){
      commit('REMOVE_TOKEN')
      //commit('REMOVE_ROLE')
      //commit('REMOVE_STATUS')
    },
    setRole({commit}, roleName){
      commit('SET_ROLE', roleName)
    }
  }
  
  export default {
    namespace: true,
    state,
    actions,
    getters,
    mutations
  }