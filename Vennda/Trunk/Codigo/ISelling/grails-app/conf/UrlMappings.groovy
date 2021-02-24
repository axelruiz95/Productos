class UrlMappings {

	static mappings = {

        "/api/$controller/$action"(controller: 'API')
        "/$controller/$action?/$id?(.$format)?"{
            constraints {
                // apply constraints here
            }
        }

        "/"(view:"/index")
        "500"(view:'/error')

        "/" {
            controller = "Indicadores"
            action = "index"
        }

	}
}