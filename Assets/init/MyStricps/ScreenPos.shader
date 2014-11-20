Shader "Kinectclother/ScreenPos" {
	Properties {
      
      _Detail ("Detail", 2D) = "gray" {}
    }
    SubShader {
      Tags { "RenderType" = "Opaque" }
      CGPROGRAM
      #pragma surface surf Lambert
      


      
      struct Input {

          float4 screenPos;
      };

      sampler2D _Detail;
      void surf (Input IN, inout SurfaceOutput o) {
          float2 screenUV = IN.screenPos.xy / IN.screenPos.w;
         
          o.Emission = tex2D (_Detail, screenUV).rgb ;//自发光
      }
      ENDCG
    } 
    Fallback "Diffuse"
  }

