Shader "Clouds" {

	Properties {
		_Color ("Ambient Color", Color) = (1.0,1.0,1.0,1.0)
		_MainTex("Diffuse Texture", 2D) = "white" {}
		_Cutoff ("Alpha Cutoff", Float) = 0.3
	}	

	SubShader 
	{
		//Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
		//LOD 200
	
		Pass 
		{
			Cull Off
			GLSLPROGRAM
			
			//#pragma surface surf Lambert alpha
	
			uniform vec4 _Time;
			uniform vec4 _Color;
			uniform sampler2D _MainTex;
			uniform vec4 _MainTex_ST;
			uniform float _Cutoff;
	
			varying vec4 texCoords;
			varying vec3 vertexPosition;
			varying vec4 vertexColor;

			
			
				
			#ifdef VERTEX
	
			void main()
			{
				vertexColor = _Color;
			
				texCoords = gl_MultiTexCoord0;
				texCoords += fract(_Time.x);
				gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
			}
	
			#endif
	
			#ifdef FRAGMENT
	
			void main()
			{
				gl_FragColor = texture2D(_MainTex, _MainTex_ST.xy * texCoords.xy + _MainTex_ST.zw) * vertexColor;
				if (gl_FragColor.a < _Cutoff)
               // alpha value less than user-specified threshold?
            	{
               		discard; // yes: discard this fragment
            	}
			}
	
			#endif
	
			ENDGLSL
		}
	}

}