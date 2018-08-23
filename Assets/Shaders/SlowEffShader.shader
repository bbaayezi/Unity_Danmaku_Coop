Shader "Custom/SlowEffShader"
{
	Properties
	{
		_TintColor ("Tint Color", Color) = (0.5,0.5,0.5,0.5)
		_MainTex ("Texture", 2D) = "white" {}
		_RotateSpeed ("Rotate Speed", Range(0, 10)) = 5
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" }
		LOD 100

		Pass
		{
			Blend One One
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			// #pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				// UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _RotateSpeed;
			fixed4 _TintColor;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				// o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.uv = float2(v.uv.x / 2, v.uv.y);
				// o.uv = v.uv.xy
				// UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// find center
				float2 uv = i.uv - float2(0.5, 0.5);
				// apply rotation
				uv = float2(uv.x * cos(_RotateSpeed * _Time.y) - uv.y * sin(_RotateSpeed * _Time.y),
				uv.x * sin(_RotateSpeed * _Time.y) + uv.y * cos(_RotateSpeed * _Time.y));
				// reset postion
				uv += float2(0.5, 0.5);
				// sample the texture
				fixed4 col = tex2D(_MainTex, uv);
				// apply fog
				// UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
